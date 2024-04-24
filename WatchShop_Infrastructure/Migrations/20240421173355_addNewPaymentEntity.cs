using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchShop_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addNewPaymentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_Shipments_ShipmentId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_AspNetUsers_ApplicationUserId",
                table: "Shipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shipments",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_orders_ShipmentId",
                table: "orders");

            migrationBuilder.RenameTable(
                name: "Shipments",
                newName: "shipments");

            migrationBuilder.RenameIndex(
                name: "IX_Shipments_ApplicationUserId",
                table: "shipments",
                newName: "IX_shipments_ApplicationUserId");

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentId",
                table: "orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_shipments",
                table: "shipments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StripeIntend = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payments_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_PaymentId",
                table: "orders",
                column: "PaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_ShipmentId",
                table: "orders",
                column: "ShipmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_payments_ApplicationUserId",
                table: "payments",
                column: "ApplicationUserId");

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
                name: "FK_shipments_AspNetUsers_ApplicationUserId",
                table: "shipments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
                name: "FK_shipments_AspNetUsers_ApplicationUserId",
                table: "shipments");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shipments",
                table: "shipments");

            migrationBuilder.DropIndex(
                name: "IX_orders_PaymentId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_ShipmentId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "orders");

            migrationBuilder.RenameTable(
                name: "shipments",
                newName: "Shipments");

            migrationBuilder.RenameIndex(
                name: "IX_shipments_ApplicationUserId",
                table: "Shipments",
                newName: "IX_Shipments_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shipments",
                table: "Shipments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_ShipmentId",
                table: "orders",
                column: "ShipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Shipments_ShipmentId",
                table: "orders",
                column: "ShipmentId",
                principalTable: "Shipments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_AspNetUsers_ApplicationUserId",
                table: "Shipments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
