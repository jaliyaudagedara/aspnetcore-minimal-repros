using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class ValuesController : ControllerBase
{
    [HttpPost("FromForm", Name = "PostFromForm")]
    public IActionResult PostFromForm([FromForm] AnalyzeRequestModel analyzeRequestModel)
    {
        return Ok(analyzeRequestModel);
    }
}