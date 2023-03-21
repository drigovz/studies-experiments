using Api.Infra.CrossCutting.DependencyInjection;
using Api.Infra.CrossCutting.Mappings;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Api.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureRepository.ConfigureDependenciesRepository(services);
            ConfigureService.ConfigureDependenciesServices(services);
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile(new DtoToModelProfile());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Schedule Barbecue Api Doc",
                    Description = "API implementada utilizando ASP.NET Core Web API version 3.1 \n" +
                                  "\nObservações importantes: \n" +
                                  "- As datas para o churrasco devem ser maior que a data e hora atual, o sistema não aceita datas que estejam no passado. \n" +
                                  "- Informar as datas no formato Unix Timestamp. Exemplo: 2021-02-19T15:18:54.092Z. \n" +
                                  "- Para iniciar a aplicação, você deve entrar no projeto Api.Application e rodar o comando \"dotnet restore\", para restaurar as dependências do projeto, depois rode o comando \"dotnet build\" para construir o projeto e por fim rode o comando \"dotnet run\" para iniciar a aplicação. \n" +
                                  "- Para que a aplicação funcione corretamente, modifique a string de conexão no arquivo Api.Data/Context/AppDbContext.cs apontando para a instância SQL Server do seu banco de dados local ou algum banco de dados na nuvem.\n",
                    TermsOfService = new Uri("https://cla.opensource.microsoft.com/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Rodrigo Vaz",
                        Email = "rodrigodp2014@gmail.com",
                        Url = new Uri("https://github.com/drigovz/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use about CLA Open Source License",
                        Url = new Uri("https://cla.opensource.microsoft.com/")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddControllers()
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile($"Logs/{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss")}.{{Date}}.log.txt", isJson: false);
            //loggerFactory.AddFile("Logs/{HalfHour}.log.txt", isJson: false);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Schedule Barbecue Api Doc");
                c.RoutePrefix = "swagger/ui";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
