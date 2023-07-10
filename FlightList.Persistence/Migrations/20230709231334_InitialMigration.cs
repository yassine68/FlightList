using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlightList.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CoordinatesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Airports_Coordinates_CoordinatesId",
                        column: x => x.CoordinatesId,
                        principalTable: "Coordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartureAirportId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ArrivalAirportId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_ArrivalAirportId",
                        column: x => x.ArrivalAirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_DepartureAirportId",
                        column: x => x.DepartureAirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude" },
                values: new object[,]
                {
                    { "59ee9bf9-83dc-49ef-9251-d31aea754a87", 33.927300000000002, -4.9786000000000001 },
                    { "5e6c365b-79d7-4324-a614-2cd3b97bb7fd", 33.3675, -7.5899720000000004 },
                    { "6b20a79e-5092-41b7-b107-9abf8df9bf9f", 31.6069, -8.0363000000000007 },
                    { "958e968e-c391-4b8a-abf2-f15bcb32dcef", 35.726900000000001, -5.9196999999999997 },
                    { "9aa05341-bbd9-4514-b0a9-4c77b9048352", 34.051400000000001, -6.7518000000000002 },
                    { "f1db0bb6-7991-43b6-bec7-2d597a3214bc", 30.324999999999999, -9.4131 }
                });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code", "CoordinatesId", "Name" },
                values: new object[,]
                {
                    { "5c531852-3334-425b-96c7-b35404a95895", "RBA", "9aa05341-bbd9-4514-b0a9-4c77b9048352", "Aéroport Rabat-Salé" },
                    { "7822d982-25ff-423b-8418-41cd6da170fe", "TNG", "958e968e-c391-4b8a-abf2-f15bcb32dcef", "Aéroport Tangier Ibn Battuta" },
                    { "7b0be66b-b6db-425e-9bee-96c5b7126301", "AGA", "f1db0bb6-7991-43b6-bec7-2d597a3214bc", "Aéroport Agadir-Al Massira" },
                    { "a2703280-4fd4-4edc-81dc-b5f8801e833f", "FEZ", "59ee9bf9-83dc-49ef-9251-d31aea754a87", "Aéroport Fès-Saïss" },
                    { "cdacc6b2-2b7d-43b6-a93d-1d2ed6530ca9", "CMN", "5e6c365b-79d7-4324-a614-2cd3b97bb7fd", "Aéroport Mohammed V de Casablanca" },
                    { "ec604f42-8e8f-43a6-be23-f6cb91c15090", "RAK", "6b20a79e-5092-41b7-b107-9abf8df9bf9f", "Aéroport Marrakech-Ménara" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airports_Code",
                table: "Airports",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Airports_CoordinatesId",
                table: "Airports",
                column: "CoordinatesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ArrivalAirportId",
                table: "Flights",
                column: "ArrivalAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DepartureAirportId",
                table: "Flights",
                column: "DepartureAirportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "Coordinates");
        }
    }
}
