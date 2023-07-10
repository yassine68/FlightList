using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightList.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addcoordinatesitem2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude" },
                values: new object[] { "85ab417f-3ccd-499b-9341-0957f907a017", 99.726900000000001, -99.919700000000006 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coordinates",
                keyColumn: "Id",
                keyValue: "85ab417f-3ccd-499b-9341-0957f907a017");
        }
    }
}
