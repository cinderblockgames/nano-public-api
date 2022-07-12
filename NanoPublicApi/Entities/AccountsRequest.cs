using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public abstract class AccountsRequest : Request
{
    
    [JsonProperty("accounts")]
    public IEnumerable<string> Accounts { get; set; }
    
}