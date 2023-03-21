using Microsoft.EntityFrameworkCore;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;

namespace NotificationService.Infra.Data.Seeding
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Template>().HasData(
            //    new Template("E-mail template exemple", "email-template-exemple", $"Emails\\Index.cshtml", TemplateType.Email)
            //);
        }
    }
}
