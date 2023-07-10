using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightList.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDateAddfroflighttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdd",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 10, 10, 32, 17, 487, DateTimeKind.Utc).AddTicks(7453));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdd",
                table: "Flights");
        }
    }
}
