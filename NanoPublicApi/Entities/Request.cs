using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities;

public class Request
{
    
    [JsonProperty("action")]
    public virtual string Action { get; set; }
    
}