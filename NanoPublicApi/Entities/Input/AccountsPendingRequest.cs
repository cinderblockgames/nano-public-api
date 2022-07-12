using System.ComponentModel;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public class AccountsPendingRequest : AccountsRequest
{
    
    [DefaultValue("accounts_pending_request")]
    public override string Action { get; set; }
    
    [JsonProperty("count")]
    public string Count { get; set; }
    
    [JsonProperty("threshold")]
    public string? Threshold { get; set; }
    
    [JsonProperty("source")]
    public string? Source { get; set; }
    
    [JsonProperty("include_active")]
    public string? IncludeActive { get; set; }
    
    [JsonProperty("sorting")]
    public string? Sorting { get; set; }
    
    [JsonProperty("include_only_confirmed")]
    public IEnumerable<string>? IncludeOnlyConfirmed { get; set; }
    
}