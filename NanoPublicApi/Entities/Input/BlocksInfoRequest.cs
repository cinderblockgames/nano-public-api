using System.ComponentModel;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public class BlocksInfoRequest : HashesRequest
{
    
    [DefaultValue("blocks_info")]
    public override string Action { get; set; }
    
    [JsonProperty("json_block", NullValueHandling = NullValueHandling.Ignore), JsonPropertyName("json_block")]
    public string? JsonBlock { get; set; }
    
    [JsonProperty("pending", NullValueHandling = NullValueHandling.Ignore)]
    public string? Pending { get; set; }
    
    [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
    public string? Source { get; set; }

    [JsonProperty("include_not_found", NullValueHandling = NullValueHandling.Ignore), JsonPropertyName("include_not_found")]
    public string? IncludeNotFound { get; set; }

}