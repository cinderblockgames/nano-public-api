using System.ComponentModel;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public class BlockAccountRequest : Request
{
    
    [DefaultValue("block_account")]
    public override string Action { get; set; }
    
    [JsonProperty("hash")]
    public string Hash { get; set; }
    
}