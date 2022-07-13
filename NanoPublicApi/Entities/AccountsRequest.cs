using Newtonsoft.Json;

namespace NanoPublicApi.Entities;

public class AccountsRequest : Request
{
    
    [JsonProperty("accounts")]
    public IEnumerable<string> Accounts { get; set; }
    
}