using System.Text.Json.Serialization;

namespace NanoPublicApi.Entities.Output;

public class AccountsPending
{
    public IDictionary<string, IDictionary<string, AccountsPending_Block>> Blocks { get; set; }

    public class AccountsPending_Block
    {
        public string Amount { get; set; }
        
        [JsonPropertyName("amount_decimal")]
        public string AmountDecimal { get; set; }
        
        public string Source { get; set; }
    }
}