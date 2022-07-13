using System.Linq;
using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using NanoPublicApi.Config;

namespace NanoPublicApi.Controllers;

[ApiController]
[Route("api")]
[Produces("application/json")]
public class ApiController : Controller
{
    private Options Options { get; }

    public ApiController(Options options)
    {
        Options = options;
    }

    [HttpGet("excluded_calls")]
    [ProducesResponseType(typeof(IEnumerable<string>), (int)HttpStatusCode.OK)]
    public IActionResult ExcludedCalls()
    {
        return Json(Options.ExcludedCalls);
    }
    
    [HttpGet("supported_calls")]
    [ProducesResponseType(typeof(IEnumerable<string>), (int)HttpStatusCode.OK)]
    public IActionResult SupportedCalls()
    {
        return Json(
            typeof(NodeController)
                .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Select(method => method.Name)
                .Except(Options.ExcludedCalls)
                .Where(call => !string.Equals(call, "Proxy", StringComparison.OrdinalIgnoreCase)) // Do not include Proxy call.
        );
    }
}