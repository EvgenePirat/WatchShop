using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchShop_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeLinkBeetwenEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_watches_ClockFaceId",
                table: "watches");

            migrationBuilder.DropIndex(
                name: "IX_watches_StrapId",
                table: "watches");

            migrationBuilder.CreateIndex(
                name: "IX_watches_ClockFaceId",
                table: "watches",
                column: "ClockFaceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_watches_StrapId",
                table: "watches",
                column: "StrapId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_watches_ClockFaceId",
                table: "watches");

            migrationBuilder.DropIndex(
                name: "IX_watches_StrapId",
                table: "watches");

            migrationBuilder.CreateIndex(
                name: "IX_watches_ClockFaceId",
                table: "watches",
                column: "ClockFaceId");

            migrationBuilder.CreateIndex(
                name: "IX_watches_StrapId",
                table: "watches",
                column: "StrapId");
        }
    }
}
