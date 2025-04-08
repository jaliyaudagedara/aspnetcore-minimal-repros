using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApplication1.Controllers;

namespace WebApplication1.Binders;

public class SomeHttpRequestModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context.Metadata.ModelType != typeof(OptionsBase))
        {
            return null;
        }

        Type[] subclasses = [typeof(ClassificationOptions), typeof(AnalyzeOptions),];

        var binders = new Dictionary<Type, (ModelMetadata, IModelBinder)>();
        foreach (Type type in subclasses)
        {
            ModelMetadata modelMetadata = context.MetadataProvider.GetMetadataForType(type);
            binders[type] = (modelMetadata, context.CreateBinder(modelMetadata));
        }

        return new SomeHttpRequestModelBinder(binders);
    }
}