using System.Text.Json.Serialization;

namespace NanoPublicApi.Entities.Output;

public class AccountHistory
{
    public string Account { get; set; }
    public IEnumerable<AccountHistory_History> History { get; set; }
    public string Previous { get; set; }

    public class AccountHistory_History
    {
        public string Type { get; set; }
        public string? Representative { get; set; }
        public string? Link { get; set; }
        public string? Balance { get; set; }
        public string? Previous { get; set; }
        public string? Subtype { get; set; }
        public string Account { get; set; }
        public string Amount { get; set; }
        
        [JsonPropertyName("local_timestamp")]
        public string LocalTimestamp { get; set; }
        
        public string Height { get; set; }
        public string Hash { get; set; }
        public string Confirmed { get; set; }
        public string? Work { get; set; }
        public string? Signature { get; set; }
    }
}