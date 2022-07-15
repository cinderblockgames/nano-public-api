using System.ComponentModel;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public class FrontiersRequest : AccountRequest, ICountRequest
{
    
    [DefaultValue("frontiers")]
    public override string Action { get; set; }
    
    [JsonProperty("count")]
    public string Count { get; set; }
    
}