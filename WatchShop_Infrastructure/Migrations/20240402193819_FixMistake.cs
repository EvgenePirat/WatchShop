using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchShop_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixMistake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Watches_WatchId1",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchAdditionalCharacteristics_AdditionalCharacteristics_AdditionalCharacteristicsId1",
                table: "WatchAdditionalCharacteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchAdditionalCharacteristics_Watches_WatchId",
                table: "WatchAdditionalCharacteristics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WatchAdditionalCharacteristics",
                table: "WatchAdditionalCharacteristics");

            migrationBuilder.DropIndex(
                name: "IX_WatchAdditionalCharacteristics_AdditionalCharacteristicsId1",
                table: "WatchAdditionalCharacteristics");

            migrationBuilder.DropIndex(
                name: "IX_Carts_WatchId1",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "AdditionalCharacteristicsId1",
                table: "WatchAdditionalCharacteristics");

            migrationBuilder.DropColumn(
                name: "WatchId1",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "AdditionalCharacteristicId",
                table: "WatchAdditionalCharacteristics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WatchAdditionalCharacteristics",
                table: "WatchAdditionalCharacteristics",
                columns: new[] { "WatchId", "AdditionalCharacteristicId" });

            migrationBuilder.CreateIndex(
                name: "IX_WatchAdditionalCharacteristics_AdditionalCharacteristicId",
                table: "WatchAdditionalCharacteristics",
                column: "AdditionalCharacteristicId");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchAdditionalCharacteristics_AdditionalCharacteristics_AdditionalCharacteristicId",
                table: "WatchAdditionalCharacteristics",
                column: "AdditionalCharacteristicId",
                principalTable: "AdditionalCharacteristics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchAdditionalCharacteristics_Watches_WatchId",
                table: "WatchAdditionalCharacteristics",
                column: "WatchId",
                principalTable: "Watches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchAdditionalCharacteristics_AdditionalCharacteristics_AdditionalCharacteristicId",
                table: "WatchAdditionalCharacteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchAdditionalCharacteristics_Watches_WatchId",
                table: "WatchAdditionalCharacteristics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WatchAdditionalCharacteristics",
                table: "WatchAdditionalCharacteristics");

            migrationBuilder.DropIndex(
                name: "IX_WatchAdditionalCharacteristics_AdditionalCharacteristicId",
                table: "WatchAdditionalCharacteristics");

            migrationBuilder.DropColumn(
                name: "AdditionalCharacteristicId",
                table: "WatchAdditionalCharacteristics");

            migrationBuilder.AddColumn<int>(
                name: "AdditionalCharacteristicsId1",
                table: "WatchAdditionalCharacteristics",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WatchId1",
                table: "Carts",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WatchAdditionalCharacteristics",
                table: "WatchAdditionalCharacteristics",
                columns: new[] { "WatchId", "AdditionalCharacteristicsId" });

            migrationBuilder.CreateIndex(
                name: "IX_WatchAdditionalCharacteristics_AdditionalCharacteristicsId1",
                table: "WatchAdditionalCharacteristics",
                column: "AdditionalCharacteristicsId1");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_WatchId1",
                table: "Carts",
                column: "WatchId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Watches_WatchId1",
                table: "Carts",
                column: "WatchId1",
                principalTable: "Watches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchAdditionalCharacteristics_AdditionalCharacteristics_AdditionalCharacteristicsId1",
                table: "WatchAdditionalCharacteristics",
                column: "AdditionalCharacteristicsId1",
                principalTable: "AdditionalCharacteristics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchAdditionalCharacteristics_Watches_WatchId",
                table: "WatchAdditionalCharacteristics",
                column: "WatchId",
                principalTable: "Watches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
