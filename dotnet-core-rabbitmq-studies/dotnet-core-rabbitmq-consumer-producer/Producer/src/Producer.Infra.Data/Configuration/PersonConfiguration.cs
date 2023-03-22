using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Producer.Core.Entities;

namespace Producer.Infra.Data.Configuration;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.FirstName).HasMaxLength(200).IsRequired();
        builder.Property(_ => _.FirstName).HasMaxLength(500).IsRequired();
    }
}