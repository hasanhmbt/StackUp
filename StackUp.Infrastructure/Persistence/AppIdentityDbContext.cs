using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using StackUp.Domain.Entities.IdentityEntites;
using StackUp.Infrastructure.Persistence.IdentityConfigurations;

namespace StackUp.Infrastructure.Persistence
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AppUserConfiguration());

            const string ADMIN_ROLE_ID = "1";
            const string ADMIN_USER_ID = "1";

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ADMIN_ROLE_ID,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            var hasher = new PasswordHasher<AppUser>();
            var adminUser = new AppUser
            {
                Id = ADMIN_USER_ID,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                FirstName = "System",
                LastName = "Administrator"
            };

            builder.Entity<AppUser>().HasData(adminUser);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_USER_ID
            });
        }
    }
}
