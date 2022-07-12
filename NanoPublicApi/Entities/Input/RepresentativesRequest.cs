using System.ComponentModel;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public class RepresentativesRequest : Request
{
    
    [DefaultValue("representatives")]
    public override string Action { get; set; }
    
    [JsonProperty("count")]
    public string? Count { get; set; }
    
    [JsonProperty("sorting")]
    public string? Sorting { get; set; }

}