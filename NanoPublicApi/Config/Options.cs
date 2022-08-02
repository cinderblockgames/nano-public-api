namespace NanoPublicApi.Config;

public class Options
{
    public IEnumerable<string> ExcludedCalls { get; set; }
    public int MaxCount { get; set; }
    public bool SupportProcess { get; set; }
}