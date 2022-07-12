using System.ComponentModel;
using Newtonsoft.Json;

namespace NanoPublicApi.Entities.Input;

public class AccountGetRequest : Request
{
    
    [DefaultValue("account_get")]
    public override string Action { get; set; }
    
    [JsonProperty("key")]
    public string Key { get; set; }
    
}