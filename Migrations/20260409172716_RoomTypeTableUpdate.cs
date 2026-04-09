using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITAssetAPI.Migrations
{
    /// <inheritdoc />
    public partial class RoomTypeTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "RoomTypeID", "RoomTypeDescription" },
                values: new object[] { 7, "IT" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeID",
                keyValue: 7);
        }
    }
}
