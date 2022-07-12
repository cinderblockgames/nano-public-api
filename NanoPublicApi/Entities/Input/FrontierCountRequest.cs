using System.ComponentModel;

namespace NanoPublicApi.Entities.Input;

public class FrontierCountRequest : Request
{
    
    [DefaultValue("frontier_count")]
    public override string Action { get; set; }
    
}