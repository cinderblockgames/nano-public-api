namespace NanoPublicApi.Entities.Output;

public class AccountsPending
{
    public IDictionary<string, IDictionary<string, AccountsPending_Block>> Blocks { get; set; }

    public class AccountsPending_Block
    {
        public string Amount { get; set; }
        public string Source { get; set; }
    }
}