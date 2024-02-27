using System.Reflection;
using Cards.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cards.DataAccess
{
    public class CardsDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public CardsDbContext(DbContextOptions<CardsDbContext> options)
            : base(options)
        {

        }

        protected override void //#D //#A
            OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.Parse("41d819ed-0b13-4cc8-9b3c-fab3b977a004"),
                    UserName = "admin@example.com",
                    NormalizedUserName = "ADMIN@EXAMPLE.COM",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEJzv...",
                    SecurityStamp = "JZ6X...",
                    ConcurrencyStamp = "d7e...",
                    PhoneNumber = "1234567890",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "user@example.com",
                    NormalizedUserName = "USER@EXAMPLE.COM",
                    Email = "user@example.com",
                    NormalizedEmail = "USER@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEJzv...",
                    SecurityStamp = "JZ6X...",
                    ConcurrencyStamp = "d7e...",
                    PhoneNumber = "1234567890",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                }
            );

            // Seed user claims
            modelBuilder.Entity<IdentityUserClaim<Guid>>().HasData(
                new IdentityUserClaim<Guid>
                {
                    Id = 1,
                    UserId = Guid.Parse("41d819ed-0b13-4cc8-9b3c-fab3b977a004"),
                    ClaimType = "Admin",
                    ClaimValue = "true"
                }
            );


        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
    }
}
