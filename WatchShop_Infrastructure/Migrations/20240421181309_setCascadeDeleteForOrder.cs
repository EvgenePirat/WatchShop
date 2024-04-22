using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchShop_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class setCascadeDeleteForOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_payments_PaymentId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_shipments_ShipmentId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_payments_AspNetUsers_ApplicationUserId",
                table: "payments");

            migrationBuilder.DropForeignKey(
                name: "FK_shipments_AspNetUsers_ApplicationUserId",
                table: "shipments");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_payments_PaymentId",
                table: "orders",
                column: "PaymentId",
                principalTable: "payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_shipments_ShipmentId",
                table: "orders",
                column: "ShipmentId",
                principalTable: "shipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_payments_PaymentId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_shipments_ShipmentId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_payments_AspNetUsers_ApplicationUserId",
                table: "payments");

            migrationBuilder.DropForeignKey(
                name: "FK_shipments_AspNetUsers_ApplicationUserId",
                table: "shipments");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_payments_PaymentId",
                table: "orders",
                column: "PaymentId",
                principalTable: "payments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_shipments_ShipmentId",
                table: "orders",
                column: "ShipmentId",
                principalTable: "shipments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_payments_AspNetUsers_ApplicationUserId",
                table: "payments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shipments_AspNetUsers_ApplicationUserId",
                table: "shipments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
