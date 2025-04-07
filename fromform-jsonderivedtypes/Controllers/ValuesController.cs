using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class ValuesController : ControllerBase
{
    [HttpPost("/FromBody", Name = "PostFromBody")]
    public IActionResult PostFromBody([FromBody] SomeHttpRequestModel someHttpRequestModel)
    {
        return Ok(someHttpRequestModel);
    }

    [HttpPost("/FromForm", Name = "PostFromForm")]
    public IActionResult PostFromForm([FromForm] SomeHttpRequestModel someHttpRequestModel)
    {
        return Ok(someHttpRequestModel);
    }
}

public class SomeHttpRequestModel
{
    public OptionsBase Options { get; set; }
}

[JsonDerivedType(typeof(ClassificationOptions), nameof(ClassificationOptions))]
[JsonDerivedType(typeof(AnalyzeOptions), nameof(AnalyzeOptions))]
public class OptionsBase
{
    public string? CommonOption1 { get; set; } = null;

}

public class ClassificationOptions : OptionsBase
{
    public string? ClassificationOption1 { get; set; }
}

public class AnalyzeOptions : OptionsBase
{
    public string? AnalyzeOptions1 { get; set; } = null;
}
