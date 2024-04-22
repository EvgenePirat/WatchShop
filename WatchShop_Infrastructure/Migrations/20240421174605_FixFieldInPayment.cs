using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchShop_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixFieldInPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StripeIntend",
                table: "payments");

            migrationBuilder.AddColumn<string>(
                name: "StripeIntendId",
                table: "payments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StripeIntendId",
                table: "payments");

            migrationBuilder.AddColumn<string>(
                name: "StripeIntend",
                table: "payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
