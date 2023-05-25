using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using NanoPublicApi.Config;
using NanoPublicApi.Connectors;

const string COIN = "NANO";
const string VERSION = "V24.0";

var env = GetEnvironmentVariables();
var node = env["NODE"];
var disableCors = bool.Parse(env["DISABLE_CORS"]);
var excludedCalls = env["EXCLUDED_CALLS"]?.Split(
    ';',
    StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
) ?? Enumerable.Empty<string>();
var maxCount = int.Parse(env["MAX_COUNT"]);
if (maxCount == 0) { maxCount = -1; }

var supportProcess = bool.Parse(env["SUPPORT_PROCESS"]);

var builder = WebApplication.CreateBuilder(args);

if (disableCors)
{
    builder.Services.AddCors(options =>
        options.AddDefaultPolicy(policy =>
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .WithMethods("get", "post"))
    );
}

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(VERSION, new OpenApiInfo
    {
        Version = VERSION,
        Title = $"{COIN} Public API",
        Contact = new OpenApiContact
        {
            Name = "GitHub",
            Url = new Uri("https://github.com/cinderblockgames/nano-public-api")
        }
    });
});

builder.Services.AddSingleton(_ => new NodeConnector(new Uri(node)));
builder.Services.AddSingleton(_ =>
    new Options
    {
        ExcludedCalls = excludedCalls,
        MaxCount = maxCount,
        SupportProcess = supportProcess
    });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint($"/swagger/{VERSION}/swagger.json", VERSION);
    options.RoutePrefix = string.Empty;
    options.DocumentTitle = $"{COIN} Public API - Swagger UI";
});

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();


static IDictionary<string, string> GetEnvironmentVariables()
{
    var env = Environment.GetEnvironmentVariables();
    var dic = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    foreach (string key in env.Keys)
    {
        dic.Add(key, (string)env[key]);
    }

    return dic;
}