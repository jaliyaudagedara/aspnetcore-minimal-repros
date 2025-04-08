namespace WebApplication1.Models;

public class AnalyzeRequestModel
{
    public IFormFileCollection Files { get; set; }

    public AnalyzeOptions Options { get; set; }
}
