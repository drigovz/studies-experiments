using Goodreads.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Goodreads.Infra.Data.EntityConfiguration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Summary)
               .HasMaxLength(300)
               .IsRequired();

        builder.HasMany(_ => _.Reviews)
               .WithOne(r => r.Book)
               .HasForeignKey(_ => _.BookId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}