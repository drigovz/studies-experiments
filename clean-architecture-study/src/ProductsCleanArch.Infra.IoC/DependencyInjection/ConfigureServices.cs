using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductsCleanArch.Application.Interfaces;
using ProductsCleanArch.Application.Mappings;
using ProductsCleanArch.Application.Services;
using System;

namespace ProductsCleanArch.Infra.IoC.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

            var handlers = AppDomain.CurrentDomain.Load("ProductsCleanArch.Application");
            services.AddMediatR(handlers);

            return services;
        }
    }
}
