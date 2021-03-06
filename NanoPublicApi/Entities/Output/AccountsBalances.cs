namespace NanoPublicApi.Entities.Output;

public class AccountsBalances
{
    public IDictionary<string, AccountsBalances_AccountBalance> Balances { get; set; }

    public class AccountsBalances_AccountBalance
    {
        public string Balance { get; set; }
        public string Pending { get; set; }
        public string Receivable { get; set; }
    }
}