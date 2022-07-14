using System.Text.Json.Serialization;

namespace NanoPublicApi.Entities.Output;

public class Receivable
{
    public IDictionary<string, Receivable_Block> Blocks { get; set; }

    public class Receivable_Block
    {
        public string Amount { get; set; }
        
        [JsonPropertyName("amount_decimal")]
        public string AmountDecimal { get; set; }
        
        public string Source { get; set; }
        
        [JsonPropertyName("min_version")]
        public string MinVersion { get; set; }
    }
}