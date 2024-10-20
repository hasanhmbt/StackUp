using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackUp.Domain.Entities.IdentityEntites;

namespace StackUp.Infrastructure.Persistence.IdentityConfigurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            builder.Property(u => u.FirstName)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(u => u.LastName)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(u => u.ImageUrl)
                .HasMaxLength(500);

            builder.Property(u => u.CreatedAt)
                .HasDefaultValue(DateTime.UtcNow);

        }
    }
}
