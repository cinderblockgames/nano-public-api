using System.ComponentModel;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public class AccountsPendingRequest : AccountsRequest
{
    
    [DefaultValue("accounts_pending_request")]
    public override string Action { get; set; }
    
    [JsonProperty("count")]
    public string Count { get; set; }
    
    [JsonProperty("threshold", NullValueHandling = NullValueHandling.Ignore)]
    public string? Threshold { get; set; }
    
    [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
    public string? Source { get; set; }
    
    [JsonProperty("include_active", NullValueHandling = NullValueHandling.Ignore), JsonPropertyName("include_active")]
    public string? IncludeActive { get; set; }
    
    [JsonProperty("sorting", NullValueHandling = NullValueHandling.Ignore)]
    public string? Sorting { get; set; }
    
    [JsonProperty("include_only_confirmed", NullValueHandling = NullValueHandling.Ignore), JsonPropertyName("include_only_confirmed")]
    public string? IncludeOnlyConfirmed { get; set; }
    
}