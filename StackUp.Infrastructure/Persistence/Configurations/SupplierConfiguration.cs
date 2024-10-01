using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackUp.Domain.Entities;

namespace StackUp.Infrastructure.Persistence.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.SupplierName)
                .IsRequired()
                .HasMaxLength(100);

            builder.OwnsOne(s => s.ContactInfo, ci =>
            {
                ci.Property(c => c.Email).HasColumnName("Email").IsRequired().HasMaxLength(100);
                ci.Property(c => c.Phone).HasColumnName("Phone").IsRequired().HasMaxLength(15);
            });

            builder.HasMany(s => s.Products)
                .WithOne(p => p.Supplier)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
