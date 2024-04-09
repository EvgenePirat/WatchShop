using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchShop_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteLinkWithWatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_watches_straps_StrapId",
                table: "watches");

            migrationBuilder.DropIndex(
                name: "IX_watches_StrapId",
                table: "watches");

            migrationBuilder.DropColumn(
                name: "StrapId",
                table: "watches");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "StrapId",
                table: "watches",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_watches_StrapId",
                table: "watches",
                column: "StrapId");

            migrationBuilder.AddForeignKey(
                name: "FK_watches_straps_StrapId",
                table: "watches",
                column: "StrapId",
                principalTable: "straps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
