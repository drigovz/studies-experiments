using Goodreads.Core.Entities;
using Goodreads.Core.Interfaces.Repository;
using Goodreads.Infra.Data.Context;
using Goodreads.Infra.Data.Repository;
using Goodreads.Infra.Data.Repository.Authors;
using Goodreads.Infra.Data.Repository.Books;
using Goodreads.Infra.Data.Repository.LiteraryGendersRepository;
using Goodreads.Infra.Data.Repository.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Goodreads.Infra.IoC.DependencyInjection;

public static class ConfigureRepository
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName))
        );

        services.AddScoped(typeof(IBaseRepository<BaseEntity, Guid>), typeof(BaseRepository<BaseEntity, Guid>));
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<ILiteraryGenderRepository, LiteraryGenderRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();

        return services;
    }

}