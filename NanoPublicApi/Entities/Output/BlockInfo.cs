using System.Text.Json.Serialization;

namespace NanoPublicApi.Entities.Output;

public class BlockInfo
{
    [JsonPropertyName("block_account")]
    public string BlockAccount { get; set; }
    
    public string Amount { get; set; }
    
    [JsonPropertyName("amount_decimal")]
    public string AmountDecimal { get; set; }

    public string Balance { get; set; }
    
    [JsonPropertyName("balance_decimal")]
    public string BalanceDecimal { get; set; }

    public string Height { get; set; }
    
    [JsonPropertyName("local_timestamp")]
    public string LocalTimestamp { get; set; }

    public string Successor { get; set; }
    public string Confirmed { get; set; }
    public BlockInfo_Contents Contents { get; set; }
    public string Subtype { get; set; }
    
    public class BlockInfo_Contents
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