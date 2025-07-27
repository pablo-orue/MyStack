using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MyStack.Infrastructure.EF;
using MyStack.KeepAlive.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddDbContext<OrueContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Orue")));


builder.Services.AddScoped<IKeepAliveService, KeepAliveService>();


if (!builder.Environment.IsDevelopment())
{
    builder.WebHost.UseUrls("http://0.0.0.0:80");
}

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
