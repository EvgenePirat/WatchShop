using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WatchShop_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addDataForRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("04d1c2c1-39fd-4570-a02a-c060e1c4578f"), null, "RoleAdmin", null },
                    { new Guid("f64b874a-5d61-492e-bba3-871b13bd8d7b"), null, "Client", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("04d1c2c1-39fd-4570-a02a-c060e1c4578f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f64b874a-5d61-492e-bba3-871b13bd8d7b"));
        }
    }
}
