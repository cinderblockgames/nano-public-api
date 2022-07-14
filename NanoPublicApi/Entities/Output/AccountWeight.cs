using System.Text.Json.Serialization;

namespace NanoPublicApi.Entities.Output;

public class AccountWeight
{
    public string Weight { get; set; }
    
    [JsonPropertyName("weight_decimal")]
    public string? WeightDecimal { get; set; }
}