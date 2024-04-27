using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchShop_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addSetNullAfterDeleteApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_AspNetUsers_UserId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_payments_AspNetUsers_ApplicationUserId",
                table: "payments");

            migrationBuilder.DropForeignKey(
                name: "FK_shipments_AspNetUsers_ApplicationUserId",
                table: "shipments");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_AspNetUsers_UserId",
                table: "orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_payments_AspNetUsers_ApplicationUserId",
                table: "payments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_shipments_AspNetUsers_ApplicationUserId",
                table: "shipments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_AspNetUsers_UserId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_payments_AspNetUsers_ApplicationUserId",
                table: "payments");

            migrationBuilder.DropForeignKey(
                name: "FK_shipments_AspNetUsers_ApplicationUserId",
                table: "shipments");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_AspNetUsers_UserId",
                table: "orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_payments_AspNetUsers_ApplicationUserId",
                table: "payments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_shipments_AspNetUsers_ApplicationUserId",
                table: "shipments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
