using Newtonsoft.Json;

namespace NanoPublicApi.Entities;

public class AccountRequest : Request
{
    
    [JsonProperty("account")]
    public string Account { get; set; }
    
}