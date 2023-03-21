using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Interfaces.Repository;
using Ecommerce.Infra.Data.Context;
using Ecommerce.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infra.IoC.DependencyInjection
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
            services.AddScoped<IClientRepository, ClientRepository>();

            return services;
        }
    }
}
