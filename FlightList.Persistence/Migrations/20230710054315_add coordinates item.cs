using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightList.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addcoordinatesitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude" },
                values: new object[] { "20a6097c-d79a-40ad-b018-58b0951e7dd0", 40.726900000000001, -6.9196999999999997 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coordinates",
                keyColumn: "Id",
                keyValue: "20a6097c-d79a-40ad-b018-58b0951e7dd0");
        }
    }
}
