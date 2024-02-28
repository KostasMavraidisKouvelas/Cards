using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cards.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IdentityUserConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserClaims",
                type: "nvarchar(34)",
                maxLength: 34,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("41d819ed-0b13-4cc8-9b3c-fab3b977a004"), 0, "d7e...", "User", "admin@example.com", true, true, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAEJzv...", "1234567890", true, "JZ6X...", false, "admin@example.com" },
                    { new Guid("d6d005b6-1878-4a4e-8ff0-f0c9e013c5ad"), 0, "d7e...", "User", "user@example.com", true, true, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEJzv...", "1234567890", true, "JZ6X...", false, "user@example.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("41d819ed-0b13-4cc8-9b3c-fab3b977a004"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d6d005b6-1878-4a4e-8ff0-f0c9e013c5ad"));

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserClaims");
        }
    }
}
