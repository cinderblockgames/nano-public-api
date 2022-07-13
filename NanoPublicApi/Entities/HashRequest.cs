using Newtonsoft.Json;

namespace NanoPublicApi.Entities;

public abstract class HashRequest : Request
{
    
    [JsonProperty("hash")]
    public string Hash { get; set; }
    
}