using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Goodreads.Core.Entities;
using Goodreads.Core.Enums;

namespace Goodreads.Infra.Data.EntityConfiguration;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Name)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(_ => _.Gender)
            .HasConversion(new EnumToStringConverter<Gender>());

        builder.Property(_ => _.Birthdate)
            .HasConversion(_ => _, _ => DateTime.SpecifyKind(_, DateTimeKind.Utc));
    }
}