using System.ComponentModel;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities;

public class RepresentativesOnlineRequest : Request
{
    
    [DefaultValue("representatives_online")]
    public override string Action { get; set; }
    
    [JsonProperty("weight")]
    public string? Weight { get; set; }
    
    [JsonProperty("accounts")]
    public IEnumerable<string>? Accounts { get; set; }

}