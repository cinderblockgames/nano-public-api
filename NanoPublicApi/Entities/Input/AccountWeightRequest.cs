using System.ComponentModel;

namespace NanoPublicApi.Entities.Input;

public class AccountWeightRequest : AccountRequest
{
    
    [DefaultValue("account_weight")]
    public override string Action { get; set; }
    
}