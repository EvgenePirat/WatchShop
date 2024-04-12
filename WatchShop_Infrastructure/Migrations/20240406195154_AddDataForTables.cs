using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WatchShop_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDataForTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "additional_characteristics",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, 1 },
                    { 2, null, 2 },
                    { 3, null, 3 },
                    { 4, null, 4 },
                    { 5, null, 5 },
                    { 6, null, 6 },
                    { 7, null, 7 },
                    { 8, null, 8 },
                    { 9, null, 9 },
                    { 10, null, 10 },
                    { 11, null, 11 },
                    { 12, null, 12 },
                    { 13, null, 13 },
                    { 14, null, 14 },
                    { 15, null, 15 },
                    { 16, null, 16 },
                    { 17, null, 17 },
                    { 18, null, 18 },
                    { 19, null, 19 },
                    { 20, null, 20 },
                    { 21, null, 21 },
                    { 22, null, 22 },
                    { 23, null, 23 },
                    { 24, null, 24 },
                    { 25, null, 25 },
                    { 26, null, 26 },
                    { 27, null, 27 },
                    { 28, null, 28 },
                    { 29, null, 29 },
                    { 30, null, 30 },
                    { 31, null, 31 },
                    { 32, null, 32 },
                    { 33, null, 33 },
                    { 34, null, 34 },
                    { 35, null, 35 },
                    { 36, null, 36 },
                    { 37, null, 37 },
                    { 38, null, 38 },
                    { 39, null, 39 },
                    { 40, null, 40 },
                    { 41, null, 41 },
                    { 42, null, 42 },
                    { 43, null, 43 },
                    { 44, null, 44 },
                    { 45, null, 45 },
                    { 46, null, 46 },
                    { 47, null, 47 },
                    { 48, null, 48 },
                    { 49, null, 49 },
                    { 50, null, 50 },
                    { 51, null, 51 },
                    { 52, null, 52 },
                    { 53, null, 53 },
                    { 54, null, 54 },
                    { 55, null, 55 },
                    { 56, null, 56 },
                    { 57, null, 57 },
                    { 58, null, 58 },
                    { 59, null, 59 },
                    { 60, null, 60 },
                    { 61, null, 61 }
                });

            migrationBuilder.InsertData(
                table: "clock_face_colors",
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
                    { (byte)12, 11 },
                    { (byte)13, 12 }
                });

            migrationBuilder.InsertData(
                table: "countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (byte)1, 1 },
                    { (byte)2, 2 },
                    { (byte)3, 3 },
                    { (byte)4, 4 },
                    { (byte)5, 5 },
                    { (byte)6, 6 },
                    { (byte)7, 7 },
                    { (byte)8, 8 },
                    { (byte)9, 9 },
                    { (byte)10, 10 },
                    { (byte)11, 11 },
                    { (byte)12, 12 },
                    { (byte)13, 13 },
                    { (byte)14, 14 },
                    { (byte)15, 15 },
                    { (byte)16, 16 },
                    { (byte)17, 17 },
                    { (byte)18, 18 },
                    { (byte)19, 19 }
                });

            migrationBuilder.InsertData(
                table: "frame_colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (byte)1, 1 },
                    { (byte)2, 2 },
                    { (byte)3, 3 },
                    { (byte)4, 4 },
                    { (byte)5, 5 },
                    { (byte)6, 6 },
                    { (byte)7, 7 },
                    { (byte)8, 8 },
                    { (byte)9, 9 },
                    { (byte)10, 10 },
                    { (byte)11, 11 },
                    { (byte)12, 12 },
                    { (byte)13, 13 },
                    { (byte)14, 14 },
                    { (byte)15, 15 },
                    { (byte)16, 16 },
                    { (byte)17, 17 },
                    { (byte)18, 18 },
                    { (byte)19, 19 }
                });

            migrationBuilder.InsertData(
                table: "frame_materials",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (byte)1, 1 },
                    { (byte)2, 2 },
                    { (byte)3, 3 },
                    { (byte)4, 4 },
                    { (byte)5, 5 },
                    { (byte)6, 6 },
                    { (byte)7, 7 },
                    { (byte)8, 8 },
                    { (byte)9, 9 },
                    { (byte)10, 10 },
                    { (byte)11, 11 },
                    { (byte)12, 12 },
                    { (byte)13, 13 },
                    { (byte)14, 14 },
                    { (byte)15, 15 },
                    { (byte)16, 16 }
                });

            migrationBuilder.InsertData(
                table: "glass_types",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { (byte)1, null, 0 },
                    { (byte)2, null, 2 },
                    { (byte)3, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "indication_kinds",
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
                    { (byte)8, 7 }
                });

            migrationBuilder.InsertData(
                table: "indication_types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (byte)1, 0 },
                    { (byte)2, 2 },
                    { (byte)3, 3 }
                });

            migrationBuilder.InsertData(
                table: "mechanism_types",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { (byte)1, null, 0 },
                    { (byte)2, null, 1 },
                    { (byte)3, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "order_statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (byte)1, 0 },
                    { (byte)2, 1 },
                    { (byte)3, 2 },
                    { (byte)4, 3 },
                    { (byte)5, 4 }
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

            migrationBuilder.InsertData(
                table: "styles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { (byte)1, null, 0 },
                    { (byte)2, null, 1 },
                    { (byte)3, null, 2 },
                    { (byte)4, null, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "additional_characteristics",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "clock_face_colors",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "clock_face_colors",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "clock_face_colors",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "clock_face_colors",
                keyColumn: "Id",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "clock_face_colors",
                keyColumn: "Id",
                keyValue: (byte)5);

            migrationBuilder.DeleteData(
                table: "clock_face_colors",
                keyColumn: "Id",
                keyValue: (byte)6);

            migrationBuilder.DeleteData(
                table: "clock_face_colors",
                keyColumn: "Id",
                keyValue: (byte)7);

            migrationBuilder.DeleteData(
                table: "clock_face_colors",
                keyColumn: "Id",
                keyValue: (byte)8);

            migrationBuilder.DeleteData(
                table: "clock_face_colors",
                keyColumn: "Id",
                keyValue: (byte)9);

            migrationBuilder.DeleteData(
                table: "clock_face_colors",
                keyColumn: "Id",
                keyValue: (byte)10);

            migrationBuilder.DeleteData(
                table: "clock_face_colors",
                keyColumn: "Id",
                keyValue: (byte)11);

            migrationBuilder.DeleteData(
                table: "clock_face_colors",
                keyColumn: "Id",
                keyValue: (byte)12);

            migrationBuilder.DeleteData(
                table: "clock_face_colors",
                keyColumn: "Id",
                keyValue: (byte)13);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: (byte)5);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: (byte)6);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: (byte)7);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: (byte)8);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: (byte)9);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: (byte)10);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: (byte)11);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: (byte)12);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: (byte)13);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: (byte)14);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: (byte)15);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: (byte)16);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: (byte)17);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: (byte)18);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: (byte)19);

            migrationBuilder.DeleteData(
                table: "frame_colors",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "frame_colors",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "frame_colors",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "frame_colors",
                keyColumn: "Id",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "frame_colors",
                keyColumn: "Id",
                keyValue: (byte)5);

            migrationBuilder.DeleteData(
                table: "frame_colors",
                keyColumn: "Id",
                keyValue: (byte)6);

            migrationBuilder.DeleteData(
                table: "frame_colors",
                keyColumn: "Id",
                keyValue: (byte)7);

            migrationBuilder.DeleteData(
                table: "frame_colors",
                keyColumn: "Id",
                keyValue: (byte)8);

            migrationBuilder.DeleteData(
                table: "frame_colors",
                keyColumn: "Id",
                keyValue: (byte)9);

            migrationBuilder.DeleteData(
                table: "frame_colors",
                keyColumn: "Id",
                keyValue: (byte)10);

            migrationBuilder.DeleteData(
                table: "frame_colors",
                keyColumn: "Id",
                keyValue: (byte)11);

            migrationBuilder.DeleteData(
                table: "frame_colors",
                keyColumn: "Id",
                keyValue: (byte)12);

            migrationBuilder.DeleteData(
                table: "frame_colors",
                keyColumn: "Id",
                keyValue: (byte)13);

            migrationBuilder.DeleteData(
                table: "frame_colors",
                keyColumn: "Id",
                keyValue: (byte)14);

            migrationBuilder.DeleteData(
                table: "frame_colors",
                keyColumn: "Id",
                keyValue: (byte)15);

            migrationBuilder.DeleteData(
                table: "frame_colors",
                keyColumn: "Id",
                keyValue: (byte)16);

            migrationBuilder.DeleteData(
                table: "frame_colors",
                keyColumn: "Id",
                keyValue: (byte)17);

            migrationBuilder.DeleteData(
                table: "frame_colors",
                keyColumn: "Id",
                keyValue: (byte)18);

            migrationBuilder.DeleteData(
                table: "frame_colors",
                keyColumn: "Id",
                keyValue: (byte)19);

            migrationBuilder.DeleteData(
                table: "frame_materials",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "frame_materials",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "frame_materials",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "frame_materials",
                keyColumn: "Id",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "frame_materials",
                keyColumn: "Id",
                keyValue: (byte)5);

            migrationBuilder.DeleteData(
                table: "frame_materials",
                keyColumn: "Id",
                keyValue: (byte)6);

            migrationBuilder.DeleteData(
                table: "frame_materials",
                keyColumn: "Id",
                keyValue: (byte)7);

            migrationBuilder.DeleteData(
                table: "frame_materials",
                keyColumn: "Id",
                keyValue: (byte)8);

            migrationBuilder.DeleteData(
                table: "frame_materials",
                keyColumn: "Id",
                keyValue: (byte)9);

            migrationBuilder.DeleteData(
                table: "frame_materials",
                keyColumn: "Id",
                keyValue: (byte)10);

            migrationBuilder.DeleteData(
                table: "frame_materials",
                keyColumn: "Id",
                keyValue: (byte)11);

            migrationBuilder.DeleteData(
                table: "frame_materials",
                keyColumn: "Id",
                keyValue: (byte)12);

            migrationBuilder.DeleteData(
                table: "frame_materials",
                keyColumn: "Id",
                keyValue: (byte)13);

            migrationBuilder.DeleteData(
                table: "frame_materials",
                keyColumn: "Id",
                keyValue: (byte)14);

            migrationBuilder.DeleteData(
                table: "frame_materials",
                keyColumn: "Id",
                keyValue: (byte)15);

            migrationBuilder.DeleteData(
                table: "frame_materials",
                keyColumn: "Id",
                keyValue: (byte)16);

            migrationBuilder.DeleteData(
                table: "glass_types",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "glass_types",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "glass_types",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "indication_kinds",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "indication_kinds",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "indication_kinds",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "indication_kinds",
                keyColumn: "Id",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "indication_kinds",
                keyColumn: "Id",
                keyValue: (byte)5);

            migrationBuilder.DeleteData(
                table: "indication_kinds",
                keyColumn: "Id",
                keyValue: (byte)6);

            migrationBuilder.DeleteData(
                table: "indication_kinds",
                keyColumn: "Id",
                keyValue: (byte)7);

            migrationBuilder.DeleteData(
                table: "indication_kinds",
                keyColumn: "Id",
                keyValue: (byte)8);

            migrationBuilder.DeleteData(
                table: "indication_types",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "indication_types",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "indication_types",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "mechanism_types",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "mechanism_types",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "mechanism_types",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "order_statuses",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "order_statuses",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "order_statuses",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "order_statuses",
                keyColumn: "Id",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "order_statuses",
                keyColumn: "Id",
                keyValue: (byte)5);

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

            migrationBuilder.DeleteData(
                table: "styles",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "styles",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "styles",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "styles",
                keyColumn: "Id",
                keyValue: (byte)4);
        }
    }
}
