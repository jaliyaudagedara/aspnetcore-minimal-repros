using System.Text.Json.Serialization;

namespace WebApplication1.Models;

[JsonDerivedType(typeof(ClassificationOptions), nameof(ClassificationOptions))]
[JsonDerivedType(typeof(ExtractionOptions), nameof(ExtractionOptions))]
public class AnalyzeOptions
{
    public string? CommonOption1 { get; set; } = null;
}