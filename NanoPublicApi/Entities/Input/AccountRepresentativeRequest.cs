using System.ComponentModel;

namespace NanoPublicApi.Entities.Input;

public class AccountRepresentativeRequest : AccountRequest
{
    
    [DefaultValue("account_representative")]
    public override string Action { get; set; }
    
}