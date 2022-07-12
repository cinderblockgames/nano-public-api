using System.ComponentModel;

namespace NanoPublicApi.Entities.Input;

public class AccountsFrontiersRequest : AccountsRequest
{
    
    [DefaultValue("accounts_frontiers")]
    public override string Action { get; set; }
    
}