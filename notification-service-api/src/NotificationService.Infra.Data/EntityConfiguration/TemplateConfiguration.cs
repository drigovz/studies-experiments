using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;

namespace NotificationService.Infra.Data.EntityConfiguration
{
    public class TemplateConfiguration : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(x => x.Subject)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.File)
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(d => d.Type)
                   .HasMaxLength(100)
                   .IsRequired()
                   .HasConversion(new EnumToStringConverter<TemplateType>());
        }
    }
}
