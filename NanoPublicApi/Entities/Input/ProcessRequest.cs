using System.ComponentModel;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public class ProcessRequest : Request
{
    
    [DefaultValue("process")]
    public override string Action { get; set; }
    
    [JsonProperty("subtype", NullValueHandling = NullValueHandling.Ignore), JsonPropertyName("subtype")]
    public string? Subtype { get; set; }
    
    [JsonProperty("json_block", NullValueHandling = NullValueHandling.Ignore), JsonPropertyName("json_block")]
    public virtual string? JsonBlock { get; set; }

    public class ProcessRequest_String : ProcessRequest
    {
        [DefaultValue("false")]
        public override string? JsonBlock { get; set; }
    
        [JsonProperty("block")]    
        public string Block { get; set; }
    }
    
    public class ProcessRequest_Json : ProcessRequest
    {
        [DefaultValue("true")]
        public override string? JsonBlock { get; set; }
    
        [JsonProperty("block")]    
        public ProcessRequest_Block Block { get; set; }
    }
    
    public class ProcessRequest_Block
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("representative")]
        public string Representative { get; set; }

        [JsonProperty("balance")]
        public string Balance { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
        
        [JsonProperty("link_as_account"), JsonPropertyName("link_as_account")]
        public string LinkAsAccount { get; set; }
        
        [JsonProperty("signature")]
        public string Signature { get; set; }
        
        [JsonProperty("work")]
        public string Work { get; set; }
    }
    
}