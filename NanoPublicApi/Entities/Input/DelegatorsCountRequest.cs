using System.ComponentModel;

namespace NanoPublicApi.Entities.Input;

public class DelegatorsCountRequest : AccountRequest
{
    
    [DefaultValue("delegators_count")]
    public override string Action { get; set; }
    
}