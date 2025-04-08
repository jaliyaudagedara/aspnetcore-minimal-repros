using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WebApplication1.Models;

namespace WebApplication1.Binders;

public class AnalyzeOptionsModelBinder : IModelBinder
{
    private Dictionary<Type, (ModelMetadata, IModelBinder)> binders;

    public AnalyzeOptionsModelBinder(Dictionary<Type, (ModelMetadata, IModelBinder)> binders)
    {
        this.binders = binders;
    }

    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        string modelKindName = ModelNames.CreatePropertyModelName(bindingContext.ModelName, "$type");
        string? modelTypeValue = bindingContext.ValueProvider.GetValue(modelKindName).FirstValue;

        IModelBinder modelBinder;
        ModelMetadata modelMetadata;
        if (modelTypeValue == nameof(ClassificationOptions))
        {
            (modelMetadata, modelBinder) = binders[typeof(ClassificationOptions)];
        }
        else if (modelTypeValue == nameof(ExtractionOptions))
        {
            (modelMetadata, modelBinder) = binders[typeof(ExtractionOptions)];
        }
        else
        {
            bindingContext.Result = ModelBindingResult.Failed();
            return;
        }

        ModelBindingContext newBindingContext = DefaultModelBindingContext.CreateBindingContext(
            bindingContext.ActionContext,
            bindingContext.ValueProvider,
            modelMetadata,
            bindingInfo: null,
            bindingContext.ModelName);

        await modelBinder.BindModelAsync(newBindingContext);
        bindingContext.Result = newBindingContext.Result;

        if (newBindingContext.Result.IsModelSet)
        {
            // Setting the ValidationState ensures properties on derived types are correctly 
            bindingContext.ValidationState[newBindingContext.Result.Model] = new ValidationStateEntry
            {
                Metadata = modelMetadata,
            };
        }
    }
}