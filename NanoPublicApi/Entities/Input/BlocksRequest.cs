using System.ComponentModel;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public class BlocksRequest : HashesRequest
{
    
    [DefaultValue("blocks")]
    public override string Action { get; set; }
    
    [JsonProperty("json_block", NullValueHandling = NullValueHandling.Ignore), JsonPropertyName("json_block")]
    public string? JsonBlock { get; set; }
    
}