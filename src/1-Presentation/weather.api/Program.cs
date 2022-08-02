using Microsoft.OpenApi.Models;
using Serilog;
using System.Text.Json;
using weather.api.Core;
using weather.cache.redis.Core;
using weather.db.sqlserver.Core;
using weather.domain.Core;
using weather.shared.logger.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c => {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        c.DescribeAllParametersInCamelCase();
        c.UseInlineDefinitionsForEnums();
    }).AddSwaggerGenNewtonsoftSupport();

builder.Services
       .AddApiServices()
       .AddLogger()
       .AddDomain()
       .AddDb(builder.Configuration)
       .AddRedis(builder.Configuration);

builder.Host.UseSerilog((ctx, lc) =>
{
    lc.WriteTo.Console();
    lc.MinimumLevel.Warning();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
