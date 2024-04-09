using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchShop_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixCascadeDeleteForWatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_watch_additional_characteristics_additional_characteristics_AdditionalCharacteristicsId",
                table: "watch_additional_characteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_watch_additional_characteristics_watches_WatchId",
                table: "watch_additional_characteristics");

            migrationBuilder.AddForeignKey(
                name: "FK_watch_additional_characteristics_additional_characteristics_AdditionalCharacteristicsId",
                table: "watch_additional_characteristics",
                column: "AdditionalCharacteristicsId",
                principalTable: "additional_characteristics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_watch_additional_characteristics_watches_WatchId",
                table: "watch_additional_characteristics",
                column: "WatchId",
                principalTable: "watches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_watch_additional_characteristics_additional_characteristics_AdditionalCharacteristicsId",
                table: "watch_additional_characteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_watch_additional_characteristics_watches_WatchId",
                table: "watch_additional_characteristics");

            migrationBuilder.AddForeignKey(
                name: "FK_watch_additional_characteristics_additional_characteristics_AdditionalCharacteristicsId",
                table: "watch_additional_characteristics",
                column: "AdditionalCharacteristicsId",
                principalTable: "additional_characteristics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_watch_additional_characteristics_watches_WatchId",
                table: "watch_additional_characteristics",
                column: "WatchId",
                principalTable: "watches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
