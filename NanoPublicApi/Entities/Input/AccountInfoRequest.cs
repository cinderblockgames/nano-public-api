using System.ComponentModel;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public class AccountInfoRequest : AccountRequest
{
    
    [DefaultValue("account_info")]
    public override string Action { get; set; }
    
    [JsonProperty("representative", NullValueHandling = NullValueHandling.Ignore)]
    public string? Representative { get; set; }

    [JsonProperty("weight", NullValueHandling = NullValueHandling.Ignore)]
    public string? Weight { get; set; }

    [JsonProperty("pending", NullValueHandling = NullValueHandling.Ignore)]
    public string? Pending { get; set; }

    [JsonProperty("receivable", NullValueHandling = NullValueHandling.Ignore)]
    public string? Receivable { get; set; }

    [JsonProperty("include_confirmed", NullValueHandling = NullValueHandling.Ignore), JsonPropertyName("include_confirmed")]
    public string? IncludeConfirmed { get; set; }
    
}