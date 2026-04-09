using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITAssetAPI.Migrations
{
    /// <inheritdoc />
    public partial class TableCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Locations_BuildingID",
                table: "Locations",
                column: "BuildingID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_RoomTypeID",
                table: "Locations",
                column: "RoomTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Buildings_BuildingID",
                table: "Locations",
                column: "BuildingID",
                principalTable: "Buildings",
                principalColumn: "BuildingID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_RoomTypes_RoomTypeID",
                table: "Locations",
                column: "RoomTypeID",
                principalTable: "RoomTypes",
                principalColumn: "RoomTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Buildings_BuildingID",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_RoomTypes_RoomTypeID",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_BuildingID",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_RoomTypeID",
                table: "Locations");
        }
    }
}
