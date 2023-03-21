using Microsoft.EntityFrameworkCore;
using NotificationService.Domain.Entities;
using NotificationService.Infra.Data.Seeding;

namespace NotificationService.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Template> Templates { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            builder.Seed();
        }
    }
}
