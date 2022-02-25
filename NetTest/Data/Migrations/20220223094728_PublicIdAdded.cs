using Microsoft.EntityFrameworkCore.Migrations;

namespace NetTest.Data.Migrations
{
    public partial class PublicIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "FuellingStations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "CarOwnerInfos",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "FuellingStations");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "CarOwnerInfos");
        }
    }
}
