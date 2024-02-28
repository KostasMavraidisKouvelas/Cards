using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards.Models;
using Microsoft.AspNetCore.Identity;

namespace Cards.DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasData(
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
        }
    }

    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserClaim> builder)
        {
            builder.HasData(
                new UserClaim
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.Parse("41d819ed-0b13-4cc8-9b3c-fab3b977a004"),
                    ClaimType = "Admin",
                    ClaimValue = "true"
                }
            );
        }
    }
}
