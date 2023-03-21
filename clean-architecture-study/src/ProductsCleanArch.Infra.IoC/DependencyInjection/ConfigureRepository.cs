using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductsCleanArch.Domain.Entities;
using ProductsCleanArch.Domain.Interfaces;
using ProductsCleanArch.Domain.Interfaces.Repository;
using ProductsCleanArch.Infra.Data.Context;
using ProductsCleanArch.Infra.Data.Repository;

namespace ProductsCleanArch.Infra.IoC.DependencyInjection
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
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
