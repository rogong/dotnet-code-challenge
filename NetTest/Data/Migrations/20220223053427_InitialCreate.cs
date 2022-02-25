using Microsoft.EntityFrameworkCore.Migrations;

namespace NetTest.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarOwnerInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Lga = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    VehicleMaker = table.Column<string>(type: "TEXT", nullable: true),
                    VehicleModel = table.Column<string>(type: "TEXT", nullable: true),
                    VehicleDocUrl = table.Column<string>(type: "TEXT", nullable: true),
                    PurchaseReceiptUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOwnerInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuellingStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnersName = table.Column<string>(type: "TEXT", nullable: true),
                    DepotReceiptUrl = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessDocUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Lga = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuellingStations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarOwnerInfos");

            migrationBuilder.DropTable(
                name: "FuellingStations");
        }
    }
}
