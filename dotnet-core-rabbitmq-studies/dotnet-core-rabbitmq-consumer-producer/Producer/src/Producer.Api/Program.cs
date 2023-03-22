using FluentValidation.AspNetCore;
using Microsoft.Extensions.Options;
using Producer.Application.Core;
using Producer.Application.Notifications;
using Producer.Core.Entities;
using Producer.Core.Interfaces.DatabaseConfig;
using Producer.Core.Interfaces.Repository;
using Producer.Infra.Data.DatabaseConfig;
using Producer.Infra.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
       .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
       .AddEnvironmentVariables();

#region [+] Repository
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection(nameof(MongoDbSettings)));
builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
builder.Services.AddScoped(typeof(IBaseRepository<BaseEntity>), typeof(BaseRepository<BaseEntity>));
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<NotificationContext>();
builder.Services.AddControllers()
    .AddFluentValidation(_ => _.RegisterValidatorsFromAssemblyContaining<NotificationContext>());
#endregion

#region [+] Services
builder.Services.AddMediatR(_ => _.RegisterServicesFromAssembly(typeof(BaseResponse).Assembly));
#endregion

builder.Services.AddControllers();
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