using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WatchShop_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteStrapTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "straps");

            migrationBuilder.DeleteData(
                table: "strap_materials",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "strap_materials",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "strap_materials",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "strap_materials",
                keyColumn: "Id",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "strap_materials",
                keyColumn: "Id",
                keyValue: (byte)5);

            migrationBuilder.DeleteData(
                table: "strap_materials",
                keyColumn: "Id",
                keyValue: (byte)6);

            migrationBuilder.DeleteData(
                table: "strap_materials",
                keyColumn: "Id",
                keyValue: (byte)7);

            migrationBuilder.DeleteData(
                table: "strap_materials",
                keyColumn: "Id",
                keyValue: (byte)8);

            migrationBuilder.DeleteData(
                table: "strap_materials",
                keyColumn: "Id",
                keyValue: (byte)9);

            migrationBuilder.DeleteData(
                table: "strap_materials",
                keyColumn: "Id",
                keyValue: (byte)10);

            migrationBuilder.DeleteData(
                table: "strap_materials",
                keyColumn: "Id",
                keyValue: (byte)11);

            migrationBuilder.DeleteData(
                table: "strap_materials",
                keyColumn: "Id",
                keyValue: (byte)12);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "straps",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    StrapMaterialId = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_straps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_straps_strap_materials_StrapMaterialId",
                        column: x => x.StrapMaterialId,
                        principalTable: "strap_materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "strap_materials",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (byte)1, 0 },
                    { (byte)2, 1 },
                    { (byte)3, 2 },
                    { (byte)4, 3 },
                    { (byte)5, 4 },
                    { (byte)6, 5 },
                    { (byte)7, 6 },
                    { (byte)8, 7 },
                    { (byte)9, 8 },
                    { (byte)10, 9 },
                    { (byte)11, 10 },
                    { (byte)12, 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_straps_StrapMaterialId",
                table: "straps",
                column: "StrapMaterialId");
        }
    }
}
