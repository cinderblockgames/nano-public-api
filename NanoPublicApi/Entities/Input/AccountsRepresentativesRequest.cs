using System.ComponentModel;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public class AccountsRepresentativesRequest : AccountsRequest
{
    
    [DefaultValue("accounts_representatives")]
    public override string Action { get; set; }
    
}