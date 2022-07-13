using System.ComponentModel;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public class AccountHistoryRequest : AccountRequest
{
    
    [DefaultValue("account_history")]
    public override string Action { get; set; }
    
    [JsonProperty("count")]
    public string Count { get; set; }
    
    [JsonProperty("raw", NullValueHandling = NullValueHandling.Ignore)]
    public string? Raw { get; set; }
    
    [JsonProperty("head", NullValueHandling = NullValueHandling.Ignore)]
    public string? Head { get; set; }
    
    [JsonProperty("offset", NullValueHandling = NullValueHandling.Ignore)]
    public string? Offset { get; set; }
    
    [JsonProperty("reverse", NullValueHandling = NullValueHandling.Ignore)]
    public string? Reverse { get; set; }
    
    [JsonProperty("account_filter", NullValueHandling = NullValueHandling.Ignore), JsonPropertyName("account_filter")]
    public IEnumerable<string>? AccountFilter { get; set; }
    
}