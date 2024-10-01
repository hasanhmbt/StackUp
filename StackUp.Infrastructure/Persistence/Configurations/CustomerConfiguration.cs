using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackUp.Domain.Entities;

namespace StackUp.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.CustomerName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(200);

            builder.OwnsOne(c => c.ContactInfo, ci =>
            {
                ci.Property(co => co.Email).HasColumnName("Email").IsRequired().HasMaxLength(100);
                ci.Property(co => co.Phone).HasColumnName("Phone").IsRequired().HasMaxLength(15);
            });

            builder.HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
