using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.Mappings
{
    class ParticipantMap : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.ToTable("Participant");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired();

            builder.Property(x => x.ContribuitionValue)
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.SugestedValue)
                   .HasDefaultValue(0)
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.SugestedValueWithDink)
                   .HasDefaultValue(0)
                   .HasColumnType("decimal(18,2)");
        }
    }
}
