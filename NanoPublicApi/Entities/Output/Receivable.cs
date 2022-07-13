namespace NanoPublicApi.Entities.Output;

public class Receivable
{
    public IDictionary<string, Receivable_Block> Blocks { get; set; }

    public class Receivable_Block
    {
        public string Amount { get; set; }
        public string Source { get; set; }
    }
}