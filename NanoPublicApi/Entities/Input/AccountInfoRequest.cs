using System.ComponentModel;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public class AccountInfoRequest : AccountRequest
{
    
    [DefaultValue("account_info")]
    public override string Action { get; set; }
    
    [JsonProperty("representative")]
    public string? Representative { get; set; }

    [JsonProperty("weight")]
    public string? Weight { get; set; }

    [JsonProperty("receivable")]
    public string? Receivable { get; set; }

    [JsonProperty("include_confirmed")]
    public string? IncludeConfirmed { get; set; }
    
}