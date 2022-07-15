using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using NanoPublicApi.Config;
using NanoPublicApi.Connectors;

var env = GetEnvironmentVariables();
var node = env["NODE"];
var disableCors = bool.Parse(env["DISABLE_CORS"]);
var excludedCalls = env["EXCLUDED_CALLS"]?.Split(
    ';',
    StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
) ?? Enumerable.Empty<string>();
var maxCount = int.Parse(env["MAX_COUNT"]);
if (maxCount == 0) { maxCount = -1; }

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
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(_ => new NodeConnector(new Uri(node)));
builder.Services.AddSingleton(_ =>
    new Options
    {
        ExcludedCalls = excludedCalls,
        MaxCount = maxCount
    });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "V23");
    options.RoutePrefix = string.Empty;
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