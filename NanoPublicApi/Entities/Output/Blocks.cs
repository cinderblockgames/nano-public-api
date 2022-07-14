using System.Text.Json.Serialization;

namespace NanoPublicApi.Entities.Output;

public class Blocks
{
    public IDictionary<string, Blocks_Block> blocks { get; set; }

    public class Blocks_Block
    {
        public string Type { get; set; }
        public string Account { get; set; }
        public string Previous { get; set; }
        public string Representative { get; set; }
        public string Balance { get; set; }
        
        [JsonPropertyName("balance_decimal")]
        public string BalanceDecimal { get; set; }
        
        public string Link { get; set; }
        
        [JsonPropertyName("link_as_account")]
        public string LinkAsAccount { get; set; }
        
        public string Signature { get; set; }
        public string Work { get; set; }
    }
}