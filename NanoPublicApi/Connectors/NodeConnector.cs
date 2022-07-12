using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace NanoPublicApi.Connectors;

public class NodeConnector
{
    
    private HttpClient Client { get; }
    
    public NodeConnector(Uri node)
    {
        Client = new HttpClient { BaseAddress = node };
    }
    
    public async Task<ContentResult> Proxy(object request)
    {
        const string mediaType = "application/json";
        var response = await Client.PostAsync(
            string.Empty,
            new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, mediaType)
        );
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        return new ContentResult { Content = result, ContentType = mediaType };
    }
    
}