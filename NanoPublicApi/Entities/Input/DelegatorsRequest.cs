using System.ComponentModel;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public class DelegatorsRequest : AccountRequest, ICountRequest
{
    
    [DefaultValue("delegators")]
    public override string Action { get; set; }
    
    [JsonProperty("threshold", NullValueHandling = NullValueHandling.Ignore)]
    public string? Threshold { get; set; }
    
    [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
    public string? Count { get; set; }

    [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
    public string? Start { get; set; }

}