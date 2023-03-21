using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Interfaces;
using NotificationService.Domain.Interfaces.Repository;
using NotificationService.Infra.Data.Context;
using NotificationService.Infra.Data.Repository;
using NotificationService.Infra.Data.Repository.Templates;

namespace NotificationService.Infra.IoC.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName))
            );

            services.AddScoped(typeof(IBaseRepository<BaseEntity, int>), typeof(BaseRepository<BaseEntity, int>));
            services.AddScoped<ITemplateRepository, TemplateRepository>();

            return services;
        }
    }
}
