using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Output;

public class AccountBlockCount
{
    
    [JsonPropertyName("block_count")]
    public string BlockCount { get; set; }
    
}