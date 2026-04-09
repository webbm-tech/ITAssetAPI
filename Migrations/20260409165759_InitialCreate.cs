using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITAssetAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    BuildingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.BuildingID);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentBrands",
                columns: table => new
                {
                    EquipmentBrandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentBrands", x => x.EquipmentBrandID);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentStatuses",
                columns: table => new
                {
                    EquipmentStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentStatuses", x => x.EquipmentStatusID);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentTypes",
                columns: table => new
                {
                    EquipmentTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTypes", x => x.EquipmentTypeID);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    RoomTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.RoomTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingID = table.Column<int>(type: "int", nullable: false),
                    RoomTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                    table.ForeignKey(
                        name: "FK_Locations_Buildings_BuildingID",
                        column: x => x.BuildingID,
                        principalTable: "Buildings",
                        principalColumn: "BuildingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locations_RoomTypes_RoomTypeID",
                        column: x => x.RoomTypeID,
                        principalTable: "RoomTypes",
                        principalColumn: "RoomTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    EquipmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherIDNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipmentTypeID = table.Column<int>(type: "int", nullable: false),
                    EquipmentBrandID = table.Column<int>(type: "int", nullable: false),
                    EquipmentStatusID = table.Column<int>(type: "int", nullable: false),
                    LocationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.EquipmentID);
                    table.ForeignKey(
                        name: "FK_Equipment_EquipmentBrands_EquipmentBrandID",
                        column: x => x.EquipmentBrandID,
                        principalTable: "EquipmentBrands",
                        principalColumn: "EquipmentBrandID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipment_EquipmentStatuses_EquipmentStatusID",
                        column: x => x.EquipmentStatusID,
                        principalTable: "EquipmentStatuses",
                        principalColumn: "EquipmentStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipment_EquipmentTypes_EquipmentTypeID",
                        column: x => x.EquipmentTypeID,
                        principalTable: "EquipmentTypes",
                        principalColumn: "EquipmentTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipment_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EquipmentBrands",
                columns: new[] { "EquipmentBrandID", "BrandName" },
                values: new object[,]
                {
                    { 1, "Dell" },
                    { 2, "HP" },
                    { 3, "Lenovo" },
                    { 4, "Apple" },
                    { 5, "ClearTouch" },
                    { 6, "Poly" },
                    { 7, "Bizhub" },
                    { 8, "Kyocera" }
                });

            migrationBuilder.InsertData(
                table: "EquipmentStatuses",
                columns: new[] { "EquipmentStatusID", "StatusDescription", "StatusName" },
                values: new object[,]
                {
                    { 1, "In use and operational", "Active" },
                    { 2, "Currently being serviced", "In Repair" },
                    { 3, "Not deployed", "In Storage" },
                    { 4, "End of life", "Retired" },
                    { 5, "Location unknown", "Missing" }
                });

            migrationBuilder.InsertData(
                table: "EquipmentTypes",
                columns: new[] { "EquipmentTypeID", "TypeName" },
                values: new object[,]
                {
                    { 1, "Desktop" },
                    { 2, "Laptop" },
                    { 3, "All-in-One" },
                    { 4, "Printer" },
                    { 5, "Interactive Display" },
                    { 6, "Phone" },
                    { 7, "Monitor" },
                    { 8, "PC Module" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "RoomTypeID", "RoomTypeDescription" },
                values: new object[,]
                {
                    { 1, "Classroom" },
                    { 2, "Computer Lab" },
                    { 3, "Faculty Office" },
                    { 4, "Staff Office" },
                    { 5, "Conference Room" },
                    { 6, "Storage" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EquipmentBrandID",
                table: "Equipment",
                column: "EquipmentBrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EquipmentStatusID",
                table: "Equipment",
                column: "EquipmentStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EquipmentTypeID",
                table: "Equipment",
                column: "EquipmentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_LocationID",
                table: "Equipment",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_BuildingID",
                table: "Locations",
                column: "BuildingID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_RoomTypeID",
                table: "Locations",
                column: "RoomTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "EquipmentBrands");

            migrationBuilder.DropTable(
                name: "EquipmentStatuses");

            migrationBuilder.DropTable(
                name: "EquipmentTypes");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}
