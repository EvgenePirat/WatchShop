using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchShop_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameAllNameTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Orders_OrderId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Watches_WatchId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Watches_WatchId1",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_ClockFace_ClockFaceColor_ClockFaceColorId",
                table: "ClockFace");

            migrationBuilder.DropForeignKey(
                name: "FK_ClockFace_IndicationKinds_IndicationKindId",
                table: "ClockFace");

            migrationBuilder.DropForeignKey(
                name: "FK_ClockFace_IndicationTypes_IndicationTypeId",
                table: "ClockFace");

            migrationBuilder.DropForeignKey(
                name: "FK_Frames_Dimensions_DimensionsId",
                table: "Frames");

            migrationBuilder.DropForeignKey(
                name: "FK_Frames_FrameColors_FrameColorId",
                table: "Frames");

            migrationBuilder.DropForeignKey(
                name: "FK_Frames_FrameMaterials_FrameMaterialId",
                table: "Frames");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrdersStatus_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Straps_StrapMaterials_StrapMaterialId",
                table: "Straps");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchAdditionalCharacteristics_AdditionalCharacteristics_AdditionalCharacteristicsId",
                table: "WatchAdditionalCharacteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchAdditionalCharacteristics_AdditionalCharacteristics_AdditionalCharacteristicsId1",
                table: "WatchAdditionalCharacteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchAdditionalCharacteristics_Watches_WatchId",
                table: "WatchAdditionalCharacteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_Watches_Brends_BrendId",
                table: "Watches");

            migrationBuilder.DropForeignKey(
                name: "FK_Watches_ClockFace_ClockFaceId",
                table: "Watches");

            migrationBuilder.DropForeignKey(
                name: "FK_Watches_Country_CountryId",
                table: "Watches");

            migrationBuilder.DropForeignKey(
                name: "FK_Watches_Frames_FrameId",
                table: "Watches");

            migrationBuilder.DropForeignKey(
                name: "FK_Watches_GlassTypes_GlassTypeId",
                table: "Watches");

            migrationBuilder.DropForeignKey(
                name: "FK_Watches_MechanismTypes_MechanismTypeId",
                table: "Watches");

            migrationBuilder.DropForeignKey(
                name: "FK_Watches_Straps_StrapId",
                table: "Watches");

            migrationBuilder.DropForeignKey(
                name: "FK_Watches_Styles_StyleId",
                table: "Watches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Watches",
                table: "Watches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Styles",
                table: "Styles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Straps",
                table: "Straps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dimensions",
                table: "Dimensions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_WatchId1",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brends",
                table: "Brends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WatchAdditionalCharacteristics",
                table: "WatchAdditionalCharacteristics");

            migrationBuilder.DropIndex(
                name: "IX_WatchAdditionalCharacteristics_AdditionalCharacteristicsId1",
                table: "WatchAdditionalCharacteristics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StrapMaterials",
                table: "StrapMaterials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersStatus",
                table: "OrdersStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MechanismTypes",
                table: "MechanismTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndicationTypes",
                table: "IndicationTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndicationKinds",
                table: "IndicationKinds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GlassTypes",
                table: "GlassTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FrameMaterials",
                table: "FrameMaterials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FrameColors",
                table: "FrameColors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClockFaceColor",
                table: "ClockFaceColor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClockFace",
                table: "ClockFace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdditionalCharacteristics",
                table: "AdditionalCharacteristics");

            migrationBuilder.DropColumn(
                name: "WatchId1",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "AdditionalCharacteristicsId1",
                table: "WatchAdditionalCharacteristics");

            migrationBuilder.RenameTable(
                name: "Watches",
                newName: "watches");

            migrationBuilder.RenameTable(
                name: "Styles",
                newName: "styles");

            migrationBuilder.RenameTable(
                name: "Straps",
                newName: "straps");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "Dimensions",
                newName: "dimensions");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "carts");

            migrationBuilder.RenameTable(
                name: "Brends",
                newName: "brends");

            migrationBuilder.RenameTable(
                name: "WatchAdditionalCharacteristics",
                newName: "watch_additional_characteristics");

            migrationBuilder.RenameTable(
                name: "StrapMaterials",
                newName: "strap_materials");

            migrationBuilder.RenameTable(
                name: "OrdersStatus",
                newName: "order_statuses");

            migrationBuilder.RenameTable(
                name: "MechanismTypes",
                newName: "mechanism_types");

            migrationBuilder.RenameTable(
                name: "IndicationTypes",
                newName: "indication_types");

            migrationBuilder.RenameTable(
                name: "IndicationKinds",
                newName: "indication_kinds");

            migrationBuilder.RenameTable(
                name: "GlassTypes",
                newName: "glass_types");

            migrationBuilder.RenameTable(
                name: "FrameMaterials",
                newName: "frame_materials");

            migrationBuilder.RenameTable(
                name: "FrameColors",
                newName: "frame_colors");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "countries");

            migrationBuilder.RenameTable(
                name: "ClockFaceColor",
                newName: "clock_face_colors");

            migrationBuilder.RenameTable(
                name: "ClockFace",
                newName: "clock_faces");

            migrationBuilder.RenameTable(
                name: "AdditionalCharacteristics",
                newName: "additional_characteristics");

            migrationBuilder.RenameIndex(
                name: "IX_Watches_StyleId",
                table: "watches",
                newName: "IX_watches_StyleId");

            migrationBuilder.RenameIndex(
                name: "IX_Watches_StrapId",
                table: "watches",
                newName: "IX_watches_StrapId");

            migrationBuilder.RenameIndex(
                name: "IX_Watches_NameModel",
                table: "watches",
                newName: "IX_watches_NameModel");

            migrationBuilder.RenameIndex(
                name: "IX_Watches_MechanismTypeId",
                table: "watches",
                newName: "IX_watches_MechanismTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Watches_GlassTypeId",
                table: "watches",
                newName: "IX_watches_GlassTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Watches_FrameId",
                table: "watches",
                newName: "IX_watches_FrameId");

            migrationBuilder.RenameIndex(
                name: "IX_Watches_CountryId",
                table: "watches",
                newName: "IX_watches_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Watches_ClockFaceId",
                table: "watches",
                newName: "IX_watches_ClockFaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Watches_BrendId",
                table: "watches",
                newName: "IX_watches_BrendId");

            migrationBuilder.RenameIndex(
                name: "IX_Straps_StrapMaterialId",
                table: "straps",
                newName: "IX_straps_StrapMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "orders",
                newName: "IX_orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrderStatusId",
                table: "orders",
                newName: "IX_orders_OrderStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_WatchId",
                table: "carts",
                newName: "IX_carts_WatchId");

            migrationBuilder.RenameIndex(
                name: "IX_Brends_Name",
                table: "brends",
                newName: "IX_brends_Name");

            migrationBuilder.RenameIndex(
                name: "IX_WatchAdditionalCharacteristics_AdditionalCharacteristicsId",
                table: "watch_additional_characteristics",
                newName: "IX_watch_additional_characteristics_AdditionalCharacteristicsId");

            migrationBuilder.RenameIndex(
                name: "IX_ClockFace_IndicationTypeId",
                table: "clock_faces",
                newName: "IX_clock_faces_IndicationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ClockFace_IndicationKindId",
                table: "clock_faces",
                newName: "IX_clock_faces_IndicationKindId");

            migrationBuilder.RenameIndex(
                name: "IX_ClockFace_ClockFaceColorId",
                table: "clock_faces",
                newName: "IX_clock_faces_ClockFaceColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_watches",
                table: "watches",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_styles",
                table: "styles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_straps",
                table: "straps",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dimensions",
                table: "dimensions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_carts",
                table: "carts",
                columns: new[] { "OrderId", "WatchId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_brends",
                table: "brends",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_watch_additional_characteristics",
                table: "watch_additional_characteristics",
                columns: new[] { "WatchId", "AdditionalCharacteristicsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_strap_materials",
                table: "strap_materials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order_statuses",
                table: "order_statuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mechanism_types",
                table: "mechanism_types",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_indication_types",
                table: "indication_types",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_indication_kinds",
                table: "indication_kinds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_glass_types",
                table: "glass_types",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_frame_materials",
                table: "frame_materials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_frame_colors",
                table: "frame_colors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_countries",
                table: "countries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clock_face_colors",
                table: "clock_face_colors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clock_faces",
                table: "clock_faces",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_additional_characteristics",
                table: "additional_characteristics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_orders_OrderId",
                table: "carts",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_carts_watches_WatchId",
                table: "carts",
                column: "WatchId",
                principalTable: "watches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_clock_faces_clock_face_colors_ClockFaceColorId",
                table: "clock_faces",
                column: "ClockFaceColorId",
                principalTable: "clock_face_colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_clock_faces_indication_kinds_IndicationKindId",
                table: "clock_faces",
                column: "IndicationKindId",
                principalTable: "indication_kinds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_clock_faces_indication_types_IndicationTypeId",
                table: "clock_faces",
                column: "IndicationTypeId",
                principalTable: "indication_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Frames_dimensions_DimensionsId",
                table: "Frames",
                column: "DimensionsId",
                principalTable: "dimensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Frames_frame_colors_FrameColorId",
                table: "Frames",
                column: "FrameColorId",
                principalTable: "frame_colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Frames_frame_materials_FrameMaterialId",
                table: "Frames",
                column: "FrameMaterialId",
                principalTable: "frame_materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_AspNetUsers_UserId",
                table: "orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_order_statuses_OrderStatusId",
                table: "orders",
                column: "OrderStatusId",
                principalTable: "order_statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_straps_strap_materials_StrapMaterialId",
                table: "straps",
                column: "StrapMaterialId",
                principalTable: "strap_materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_watches_Frames_FrameId",
                table: "watches",
                column: "FrameId",
                principalTable: "Frames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_watches_brends_BrendId",
                table: "watches",
                column: "BrendId",
                principalTable: "brends",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_watches_clock_faces_ClockFaceId",
                table: "watches",
                column: "ClockFaceId",
                principalTable: "clock_faces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_watches_countries_CountryId",
                table: "watches",
                column: "CountryId",
                principalTable: "countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_watches_glass_types_GlassTypeId",
                table: "watches",
                column: "GlassTypeId",
                principalTable: "glass_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_watches_mechanism_types_MechanismTypeId",
                table: "watches",
                column: "MechanismTypeId",
                principalTable: "mechanism_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_watches_straps_StrapId",
                table: "watches",
                column: "StrapId",
                principalTable: "straps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_watches_styles_StyleId",
                table: "watches",
                column: "StyleId",
                principalTable: "styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_orders_OrderId",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_carts_watches_WatchId",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_clock_faces_clock_face_colors_ClockFaceColorId",
                table: "clock_faces");

            migrationBuilder.DropForeignKey(
                name: "FK_clock_faces_indication_kinds_IndicationKindId",
                table: "clock_faces");

            migrationBuilder.DropForeignKey(
                name: "FK_clock_faces_indication_types_IndicationTypeId",
                table: "clock_faces");

            migrationBuilder.DropForeignKey(
                name: "FK_Frames_dimensions_DimensionsId",
                table: "Frames");

            migrationBuilder.DropForeignKey(
                name: "FK_Frames_frame_colors_FrameColorId",
                table: "Frames");

            migrationBuilder.DropForeignKey(
                name: "FK_Frames_frame_materials_FrameMaterialId",
                table: "Frames");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_AspNetUsers_UserId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_order_statuses_OrderStatusId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_straps_strap_materials_StrapMaterialId",
                table: "straps");

            migrationBuilder.DropForeignKey(
                name: "FK_watch_additional_characteristics_additional_characteristics_AdditionalCharacteristicsId",
                table: "watch_additional_characteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_watch_additional_characteristics_watches_WatchId",
                table: "watch_additional_characteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_watches_Frames_FrameId",
                table: "watches");

            migrationBuilder.DropForeignKey(
                name: "FK_watches_brends_BrendId",
                table: "watches");

            migrationBuilder.DropForeignKey(
                name: "FK_watches_clock_faces_ClockFaceId",
                table: "watches");

            migrationBuilder.DropForeignKey(
                name: "FK_watches_countries_CountryId",
                table: "watches");

            migrationBuilder.DropForeignKey(
                name: "FK_watches_glass_types_GlassTypeId",
                table: "watches");

            migrationBuilder.DropForeignKey(
                name: "FK_watches_mechanism_types_MechanismTypeId",
                table: "watches");

            migrationBuilder.DropForeignKey(
                name: "FK_watches_straps_StrapId",
                table: "watches");

            migrationBuilder.DropForeignKey(
                name: "FK_watches_styles_StyleId",
                table: "watches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_watches",
                table: "watches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_styles",
                table: "styles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_straps",
                table: "straps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dimensions",
                table: "dimensions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_carts",
                table: "carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_brends",
                table: "brends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_watch_additional_characteristics",
                table: "watch_additional_characteristics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_strap_materials",
                table: "strap_materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order_statuses",
                table: "order_statuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mechanism_types",
                table: "mechanism_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_indication_types",
                table: "indication_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_indication_kinds",
                table: "indication_kinds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_glass_types",
                table: "glass_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_frame_materials",
                table: "frame_materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_frame_colors",
                table: "frame_colors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_countries",
                table: "countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clock_faces",
                table: "clock_faces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clock_face_colors",
                table: "clock_face_colors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_additional_characteristics",
                table: "additional_characteristics");

            migrationBuilder.RenameTable(
                name: "watches",
                newName: "Watches");

            migrationBuilder.RenameTable(
                name: "styles",
                newName: "Styles");

            migrationBuilder.RenameTable(
                name: "straps",
                newName: "Straps");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "dimensions",
                newName: "Dimensions");

            migrationBuilder.RenameTable(
                name: "carts",
                newName: "Carts");

            migrationBuilder.RenameTable(
                name: "brends",
                newName: "Brends");

            migrationBuilder.RenameTable(
                name: "watch_additional_characteristics",
                newName: "WatchAdditionalCharacteristics");

            migrationBuilder.RenameTable(
                name: "strap_materials",
                newName: "StrapMaterials");

            migrationBuilder.RenameTable(
                name: "order_statuses",
                newName: "OrdersStatus");

            migrationBuilder.RenameTable(
                name: "mechanism_types",
                newName: "MechanismTypes");

            migrationBuilder.RenameTable(
                name: "indication_types",
                newName: "IndicationTypes");

            migrationBuilder.RenameTable(
                name: "indication_kinds",
                newName: "IndicationKinds");

            migrationBuilder.RenameTable(
                name: "glass_types",
                newName: "GlassTypes");

            migrationBuilder.RenameTable(
                name: "frame_materials",
                newName: "FrameMaterials");

            migrationBuilder.RenameTable(
                name: "frame_colors",
                newName: "FrameColors");

            migrationBuilder.RenameTable(
                name: "countries",
                newName: "Country");

            migrationBuilder.RenameTable(
                name: "clock_faces",
                newName: "ClockFace");

            migrationBuilder.RenameTable(
                name: "clock_face_colors",
                newName: "ClockFaceColor");

            migrationBuilder.RenameTable(
                name: "additional_characteristics",
                newName: "AdditionalCharacteristics");

            migrationBuilder.RenameIndex(
                name: "IX_watches_StyleId",
                table: "Watches",
                newName: "IX_Watches_StyleId");

            migrationBuilder.RenameIndex(
                name: "IX_watches_StrapId",
                table: "Watches",
                newName: "IX_Watches_StrapId");

            migrationBuilder.RenameIndex(
                name: "IX_watches_NameModel",
                table: "Watches",
                newName: "IX_Watches_NameModel");

            migrationBuilder.RenameIndex(
                name: "IX_watches_MechanismTypeId",
                table: "Watches",
                newName: "IX_Watches_MechanismTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_watches_GlassTypeId",
                table: "Watches",
                newName: "IX_Watches_GlassTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_watches_FrameId",
                table: "Watches",
                newName: "IX_Watches_FrameId");

            migrationBuilder.RenameIndex(
                name: "IX_watches_CountryId",
                table: "Watches",
                newName: "IX_Watches_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_watches_ClockFaceId",
                table: "Watches",
                newName: "IX_Watches_ClockFaceId");

            migrationBuilder.RenameIndex(
                name: "IX_watches_BrendId",
                table: "Watches",
                newName: "IX_Watches_BrendId");

            migrationBuilder.RenameIndex(
                name: "IX_straps_StrapMaterialId",
                table: "Straps",
                newName: "IX_Straps_StrapMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_UserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_OrderStatusId",
                table: "Orders",
                newName: "IX_Orders_OrderStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_carts_WatchId",
                table: "Carts",
                newName: "IX_Carts_WatchId");

            migrationBuilder.RenameIndex(
                name: "IX_brends_Name",
                table: "Brends",
                newName: "IX_Brends_Name");

            migrationBuilder.RenameIndex(
                name: "IX_watch_additional_characteristics_AdditionalCharacteristicsId",
                table: "WatchAdditionalCharacteristics",
                newName: "IX_WatchAdditionalCharacteristics_AdditionalCharacteristicsId");

            migrationBuilder.RenameIndex(
                name: "IX_clock_faces_IndicationTypeId",
                table: "ClockFace",
                newName: "IX_ClockFace_IndicationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_clock_faces_IndicationKindId",
                table: "ClockFace",
                newName: "IX_ClockFace_IndicationKindId");

            migrationBuilder.RenameIndex(
                name: "IX_clock_faces_ClockFaceColorId",
                table: "ClockFace",
                newName: "IX_ClockFace_ClockFaceColorId");

            migrationBuilder.AddColumn<int>(
                name: "WatchId1",
                table: "Carts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdditionalCharacteristicsId1",
                table: "WatchAdditionalCharacteristics",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Watches",
                table: "Watches",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Styles",
                table: "Styles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Straps",
                table: "Straps",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dimensions",
                table: "Dimensions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                columns: new[] { "OrderId", "WatchId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brends",
                table: "Brends",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WatchAdditionalCharacteristics",
                table: "WatchAdditionalCharacteristics",
                columns: new[] { "WatchId", "AdditionalCharacteristicsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StrapMaterials",
                table: "StrapMaterials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersStatus",
                table: "OrdersStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MechanismTypes",
                table: "MechanismTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndicationTypes",
                table: "IndicationTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndicationKinds",
                table: "IndicationKinds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GlassTypes",
                table: "GlassTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FrameMaterials",
                table: "FrameMaterials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FrameColors",
                table: "FrameColors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClockFace",
                table: "ClockFace",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClockFaceColor",
                table: "ClockFaceColor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdditionalCharacteristics",
                table: "AdditionalCharacteristics",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_WatchId1",
                table: "Carts",
                column: "WatchId1");

            migrationBuilder.CreateIndex(
                name: "IX_WatchAdditionalCharacteristics_AdditionalCharacteristicsId1",
                table: "WatchAdditionalCharacteristics",
                column: "AdditionalCharacteristicsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Orders_OrderId",
                table: "Carts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Watches_WatchId",
                table: "Carts",
                column: "WatchId",
                principalTable: "Watches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Watches_WatchId1",
                table: "Carts",
                column: "WatchId1",
                principalTable: "Watches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClockFace_ClockFaceColor_ClockFaceColorId",
                table: "ClockFace",
                column: "ClockFaceColorId",
                principalTable: "ClockFaceColor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClockFace_IndicationKinds_IndicationKindId",
                table: "ClockFace",
                column: "IndicationKindId",
                principalTable: "IndicationKinds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClockFace_IndicationTypes_IndicationTypeId",
                table: "ClockFace",
                column: "IndicationTypeId",
                principalTable: "IndicationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Frames_Dimensions_DimensionsId",
                table: "Frames",
                column: "DimensionsId",
                principalTable: "Dimensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Frames_FrameColors_FrameColorId",
                table: "Frames",
                column: "FrameColorId",
                principalTable: "FrameColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Frames_FrameMaterials_FrameMaterialId",
                table: "Frames",
                column: "FrameMaterialId",
                principalTable: "FrameMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrdersStatus_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId",
                principalTable: "OrdersStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Straps_StrapMaterials_StrapMaterialId",
                table: "Straps",
                column: "StrapMaterialId",
                principalTable: "StrapMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchAdditionalCharacteristics_AdditionalCharacteristics_AdditionalCharacteristicsId",
                table: "WatchAdditionalCharacteristics",
                column: "AdditionalCharacteristicsId",
                principalTable: "AdditionalCharacteristics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Watches_Brends_BrendId",
                table: "Watches",
                column: "BrendId",
                principalTable: "Brends",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Watches_ClockFace_ClockFaceId",
                table: "Watches",
                column: "ClockFaceId",
                principalTable: "ClockFace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Watches_Country_CountryId",
                table: "Watches",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Watches_Frames_FrameId",
                table: "Watches",
                column: "FrameId",
                principalTable: "Frames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Watches_GlassTypes_GlassTypeId",
                table: "Watches",
                column: "GlassTypeId",
                principalTable: "GlassTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Watches_MechanismTypes_MechanismTypeId",
                table: "Watches",
                column: "MechanismTypeId",
                principalTable: "MechanismTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Watches_Straps_StrapId",
                table: "Watches",
                column: "StrapId",
                principalTable: "Straps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Watches_Styles_StyleId",
                table: "Watches",
                column: "StyleId",
                principalTable: "Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
