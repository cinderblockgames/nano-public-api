using System.ComponentModel;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public class RepresentativesRequest : Request, ICountRequest
{
    
    [DefaultValue("representatives")]
    public override string Action { get; set; }
    
    [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
    public string? Count { get; set; }
    
    [JsonProperty("sorting", NullValueHandling = NullValueHandling.Ignore)]
    public string? Sorting { get; set; }

}