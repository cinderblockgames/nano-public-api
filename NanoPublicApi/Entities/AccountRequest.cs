using Newtonsoft.Json;

namespace NanoPublicApi.Entities;

public abstract class AccountRequest : Request
{
    
    [JsonProperty("account")]
    public string Account { get; set; }
    
}