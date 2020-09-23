namespace Infrastructure.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EnrollConfiguration : IEntityTypeConfiguration<Enrollee>
    {
        public void Configure(EntityTypeBuilder<Enrollee> builder)
        {
            
        }
    }
}
