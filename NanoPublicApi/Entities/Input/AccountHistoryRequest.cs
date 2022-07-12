using System.ComponentModel;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public class AccountHistoryRequest : AccountRequest
{
    
    [DefaultValue("account_history")]
    public override string Action { get; set; }
    
    [JsonProperty("count")]
    public string Count { get; set; }
    
    [JsonProperty("raw")]
    public string? Raw { get; set; }
    
    [JsonProperty("head")]
    public string? Head { get; set; }
    
    [JsonProperty("offset")]
    public string? Offset { get; set; }
    
    [JsonProperty("reverse")]
    public string? Reverse { get; set; }
    
    [JsonProperty("account_filter")]
    public IEnumerable<string>? AccountFilter { get; set; }
    
}