using Newtonsoft.Json;

namespace NanoPublicApi.Entities;

public class HashRequest : Request
{
    
    [JsonProperty("hash")]
    public string Hash { get; set; }
    
}