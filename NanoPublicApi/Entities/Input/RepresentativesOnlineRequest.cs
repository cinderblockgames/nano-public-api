using System.ComponentModel;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities;

public class RepresentativesOnlineRequest : Request
{
    
    [DefaultValue("representatives_online")]
    public override string Action { get; set; }
    
    [JsonProperty("weight", NullValueHandling = NullValueHandling.Ignore)]
    public string? Weight { get; set; }
    
    [JsonProperty("accounts", NullValueHandling = NullValueHandling.Ignore)]
    public IEnumerable<string>? Accounts { get; set; }

}