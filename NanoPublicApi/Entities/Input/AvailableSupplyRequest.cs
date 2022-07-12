using System.ComponentModel;

namespace NanoPublicApi.Entities;

public class AvailableSupplyRequest : Request
{
    
    [DefaultValue("available_supply")]
    public override string Action { get; set; }
    
}