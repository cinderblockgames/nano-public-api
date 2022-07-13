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
    
    #region " Static "
    
    private static IEnumerable<string> AllCalls { get; }
    
    static ApiController()
    {
        AllCalls = typeof(NodeController)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .Select(method => method.Name)
            .Where(call =>
                !string.Equals(call, "Proxy", StringComparison.OrdinalIgnoreCase)); // Do not include Proxy call.
    }
    
    #endregion
    
    #region " Instance "

    private Options Options { get; }

    public ApiController(Options options)
    {
        Options = options;
    }
    
    #endregion

    [HttpGet("excluded_calls")]
    [ProducesResponseType(typeof(IEnumerable<string>), (int)HttpStatusCode.OK)]
    public IActionResult ExcludedCalls()
    {
        return Json(AllCalls.Intersect(Options.ExcludedCalls));
    }

    [HttpGet("supported_calls")]
    [ProducesResponseType(typeof(IEnumerable<string>), (int)HttpStatusCode.OK)]
    public IActionResult SupportedCalls()
    {
        return Json(AllCalls.Except(Options.ExcludedCalls));
    }
    
}