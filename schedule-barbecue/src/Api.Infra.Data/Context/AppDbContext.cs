using Api.Domain.Entities;
using Api.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.IO;

namespace Api.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public AppDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get connection string value of appsettings.json
            //var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            //.AddJsonFile($"appsettings.{envName}.json", optional: false)
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .Build();

            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            //var connectionString = configuration["ConnectionStrings:DefaultConnection"];

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Barbecue>(new BarbecueMap().Configure);
            modelBuilder.Entity<Participant>(new ParticipantMap().Configure);
        }

        public DbSet<Barbecue> Barbecues { get; set; }
        public DbSet<Participant> Participants { get; set; }
    }
}
