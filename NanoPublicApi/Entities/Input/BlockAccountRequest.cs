using System.ComponentModel;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public class BlockAccountRequest : HashRequest
{
    
    [DefaultValue("block_account")]
    public override string Action { get; set; }
    
}