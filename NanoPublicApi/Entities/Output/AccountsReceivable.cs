namespace NanoPublicApi.Entities.Output;

public class AccountsReceivable
{
    public IDictionary<string, IDictionary<string, AccountsReceivable_Block>> Blocks { get; set; }

    public class AccountsReceivable_Block
    {
        public string Amount { get; set; }
        public string Source { get; set; }
    }
}