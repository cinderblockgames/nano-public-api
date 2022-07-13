using System.ComponentModel;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public class DelegatorsRequest : AccountRequest
{
    
    [DefaultValue("delegators")]
    public override string Action { get; set; }
    
    [JsonProperty("threshold")]
    public string? Threshold { get; set; }
    
    [JsonProperty("count")]
    public string? Count { get; set; }

    [JsonProperty("start")]
    public string? Start { get; set; }

}