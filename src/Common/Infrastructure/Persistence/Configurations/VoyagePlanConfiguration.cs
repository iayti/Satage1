namespace Infrastructure.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class VoyagePlanConfiguration : IEntityTypeConfiguration<VoyagePlan>
    {
        public void Configure(EntityTypeBuilder<VoyagePlan> builder)
        {
            builder.Property(t => t.Date).IsRequired();

            builder.Property(t => t.Description)
                .HasMaxLength(200);
        }
    }
}
