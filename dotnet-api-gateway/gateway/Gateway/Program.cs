using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

#region [+] Create Host Builder
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"configuration.{builder.Environment.EnvironmentName}.json")
                    .AddEnvironmentVariables();
#endregion

builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();
app.MapGet("/", async context =>
    {
        await context.Response.WriteAsJsonAsync("API gateway is running");
    });
app.UseOcelot().Wait();
app.Run();
