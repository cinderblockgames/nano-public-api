using System.Text.Json.Serialization;

namespace NanoPublicApi.Entities.Output;

public class AccountBalance
{
    public string Balance { get; set; }
    
    [JsonPropertyName("balance_decimal")]
    public string BalanceDecimal { get; set; }
    
    public string Pending { get; set; }
    
    [JsonPropertyName("pending_decimal")]
    public string PendingDecimal { get; set; }
    
    public string Receivable { get; set; }
    
    [JsonPropertyName("receivable_decimal")]
    public string ReceivableDecimal { get; set; }
    
}