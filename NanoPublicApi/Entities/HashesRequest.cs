using Newtonsoft.Json;

namespace NanoPublicApi.Entities;

public class HashesRequest : Request
{
    
    [JsonProperty("hashes")]
    public IEnumerable<string> Hashes { get; set; }
    
}