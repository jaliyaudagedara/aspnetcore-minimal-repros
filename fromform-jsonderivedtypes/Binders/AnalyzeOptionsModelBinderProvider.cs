using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApplication1.Models;

namespace WebApplication1.Binders;

public class AnalyzeOptionsModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context.Metadata.ModelType != typeof(AnalyzeOptions))
        {
            return null;
        }

        Type[] subclasses = [typeof(ClassificationOptions), typeof(ExtractionOptions),];

        var binders = new Dictionary<Type, (ModelMetadata, IModelBinder)>();
        foreach (Type type in subclasses)
        {
            ModelMetadata modelMetadata = context.MetadataProvider.GetMetadataForType(type);
            binders[type] = (modelMetadata, context.CreateBinder(modelMetadata));
        }

        return new AnalyzeOptionsModelBinder(binders);
    }
}