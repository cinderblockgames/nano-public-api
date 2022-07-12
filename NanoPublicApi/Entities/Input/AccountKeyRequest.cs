using System.ComponentModel;

namespace NanoPublicApi.Entities.Input;

public class AccountKeyRequest : AccountRequest
{
    
    [DefaultValue("account_key")]
    public override string Action { get; set; }
    
}