using System.Text.Json.Serialization;

namespace NanoPublicApi.Entities.Output;

public class AccountInfo
{
    public string Frontier { get; set; }
    
    [JsonPropertyName("open_block")]
    public string OpenBlock { get; set; }
    
    [JsonPropertyName("representative_block")]
    public string RepresentativeBlock { get; set; }
    
    public string Balance { get; set; }
    
    [JsonPropertyName("balance_decimal")]
    public string BalanceDecimal { get; set; }
    
    [JsonPropertyName("confirmed_balance")]
    public string? ConfirmedBalance { get; set; }
    
    [JsonPropertyName("modified_timestamp")]
    public string ModifiedTimestamp { get; set; }
    
    [JsonPropertyName("block_count")]
    public string BlockCount { get; set; }
    
    [JsonPropertyName("account_version")]
    public string AccountVersion { get; set; }
    
    [JsonPropertyName("confirmation_height")]
    public string? ConfirmationHeight { get; set; }
    
    [JsonPropertyName("confirmed_height")]
    public string? ConfirmedHeight { get; set; }
    
    [JsonPropertyName("confirmation_height_frontier")]
    public string? ConfirmationHeightFrontier { get; set; }
    
    [JsonPropertyName("confirmed_frontier")]
    public string? ConfirmedFrontier { get; set; }
    
    public string? Representative { get; set; }
    
    [JsonPropertyName("confirmed_representative")]
    public string? ConfirmedRepresentative { get; set; }
    
    public string? Weight { get; set; }
    
    [JsonPropertyName("weight_decimal")]
    public string? WeightDecimal { get; set; }

    [JsonPropertyName("weight_decimal_millions")]
    public string? WeightDecimalMillions { get; set; }

    public string? Pending { get; set; }
    
    [JsonPropertyName("pending_decimal")]
    public string? PendingDecimal { get; set; }

    public string? Receivable { get; set; }
        
    [JsonPropertyName("receivable_decimal")]
    public string? ReceivableDecimal { get; set; }

    [JsonPropertyName("confirmed_pending")]
    public string? ConfirmedPending { get; set; }

    [JsonPropertyName("confirmed_pending_decimal")]
    public string? ConfirmedPendingDecimal { get; set; }
    
    [JsonPropertyName("confirmed_receivable")]
    public string? ConfirmedReceivable { get; set; }
    
    [JsonPropertyName("confirmed_receivable_decimal")]
    public string? ConfirmedReceivableDecimal { get; set; }
}