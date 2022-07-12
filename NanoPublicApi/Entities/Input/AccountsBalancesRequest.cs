using System.ComponentModel;

namespace NanoPublicApi.Entities.Input;

public class AccountsBalancesRequest : AccountsRequest
{
    
    [DefaultValue("accounts_balances")]
    public override string Action { get; set; }
    
}