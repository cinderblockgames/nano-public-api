using System.ComponentModel;

namespace NanoPublicApi.Entities.Input;

public class AccountBlockCountRequest : AccountRequest
{
    
    [DefaultValue("account_block_count")]
    public override string Action { get; set; }
    
}