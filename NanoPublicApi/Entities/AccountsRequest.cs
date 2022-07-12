using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public abstract class AccountsRequest : Request
{
    
    [JsonProperty("account")]
    public IEnumerable<string> Account { get; set; }
    
}