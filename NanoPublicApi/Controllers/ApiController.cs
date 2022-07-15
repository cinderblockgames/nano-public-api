using System.Net;
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using NanoPublicApi.Config;
using Newtonsoft.Json;

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

    [HttpGet("api_info")]
    [ProducesResponseType(typeof(AggregatedApiInfo), (int)HttpStatusCode.OK)]
    public IActionResult ApiInfo()
    {
        return Json(new AggregatedApiInfo
        {
            ExcludedCalls = AllCalls.Intersect(Options.ExcludedCalls),
            SupportedCalls = AllCalls.Except(Options.ExcludedCalls),
            MaxCount = Options.MaxCount
        });
    }

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

    [HttpGet("max_count")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public IActionResult MaxCount()
    {
        return Json(Options.MaxCount);
    }
    
    #region " AggregatedApiInfo "

    public class AggregatedApiInfo
    {
        [JsonPropertyName("excluded_calls")]
        public IEnumerable<string> ExcludedCalls { get; set; }
        
        [JsonPropertyName("supported_calls")]
        public IEnumerable<string> SupportedCalls { get; set; }
        
        [JsonPropertyName("max_count")]
        public int MaxCount { get; set; }
    }
    
    #endregion
    
}