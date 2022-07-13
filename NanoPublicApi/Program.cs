using System.Text.Json.Serialization;
using NanoPublicApi.Config;
using NanoPublicApi.Connectors;

var env = Environment.GetEnvironmentVariables();
var node = env["NODE"] as string;
var disableCors = bool.Parse(env["DISABLE_CORS"] as string);
var excludedCalls = (env["EXCLUDED_CALLS"] as string)?.Split(';') ?? Enumerable.Empty<string>();

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
builder.Services.AddSingleton(_ => new Options { ExcludedCalls = excludedCalls });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v23.3");
    options.RoutePrefix = string.Empty;
});

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();