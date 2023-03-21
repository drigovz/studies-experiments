using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.Mappings
{
    public class BarbecueMap : IEntityTypeConfiguration<Barbecue>
    {
        public void Configure(EntityTypeBuilder<Barbecue> builder)
        {
            builder.ToTable("Barbecue");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Date)
                   .IsRequired();

            builder.Property(x => x.Description)
                    .IsRequired()
                    .HasMaxLength(200);
        }
    }
}
