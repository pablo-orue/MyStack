using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using MyStack.Infrastructure.EF;
using MyStack.KeepAlive.Service;
using MyStack.Money.Service;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Configuration.AddAzureKeyVault(
    new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
    new DefaultAzureCredential());


builder.Services.AddDbContext<OrueContext>(options => options.UseSqlServer(builder.Configuration["OrueConnectionString"]));

builder.Services.AddScoped<IKeepAliveService, KeepAliveService>();
builder.Services.AddScoped<ITradeService, TradeService>();

if (!builder.Environment.IsDevelopment())
{
    builder.WebHost.UseUrls("http://0.0.0.0:80");
}
builder.Services.AddApplicationInsightsTelemetry(new Microsoft.ApplicationInsights.AspNetCore.Extensions.ApplicationInsightsServiceOptions
{
    ConnectionString = builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<HeaderChecker>();
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
