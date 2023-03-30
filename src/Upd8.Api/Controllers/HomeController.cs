using Microsoft.AspNetCore.Mvc;

namespace Upd8.Api.Controllers;

[ApiController]
[Route("")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Home()
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var netversion = Environment.Version.ToString();

        return Ok(new { environment, netversion });
    }
}