using System.ComponentModel;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public class BlockInfoRequest : HashRequest
{
    
    [DefaultValue("block_info")]
    public override string Action { get; set; }
    
    [JsonProperty("json_block", NullValueHandling = NullValueHandling.Ignore), JsonPropertyName("json_block")]
    public string? JsonBlock { get; set; }
    
}