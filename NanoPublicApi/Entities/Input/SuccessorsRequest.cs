using System.ComponentModel;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public class SuccessorsRequest : Request, ICountRequest
{
    
    [DefaultValue("successors")]
    public override string Action { get; set; }
    
    [JsonProperty("block")]
    public string Block { get; set; }

    [JsonProperty("count")]
    public string Count { get; set; }
    
    [JsonProperty("offset", NullValueHandling = NullValueHandling.Ignore)]
    public string? Offset { get; set; }
    
    [JsonProperty("reverse", NullValueHandling = NullValueHandling.Ignore)]
    public string? Reverse { get; set; }
    
}