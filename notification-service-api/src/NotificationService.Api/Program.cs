using FluentValidation.AspNetCore;
using NotificationService.Application.Notifications;
using NotificationService.Infra.IoC.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
                     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                     .AddEnvironmentVariables();

builder.Services.AddServices(builder.Configuration);
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddScoped<NotificationContext>();
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<NotificationContext>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var env = app.Environment;
if (app.Environment.IsDevelopment() || env.EnvironmentName == "Local")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
