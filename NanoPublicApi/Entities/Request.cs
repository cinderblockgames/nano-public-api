using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities;

public abstract class Request
{
    
    [JsonProperty("action")]
    public abstract string Action { get; set; }
    
}