using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public abstract class AccountRequest : Request
{
    
    [JsonProperty("account")]
    public string Account { get; set; }
    
}