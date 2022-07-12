using System.ComponentModel;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public class AccountBalanceRequest : AccountRequest
{
    
    [DefaultValue("account_balance")]
    public override string Action { get; set; }
    
    [JsonProperty("include_only_confirmed")]
    public string? IncludeOnlyConfirmed { get; set; }
    
}