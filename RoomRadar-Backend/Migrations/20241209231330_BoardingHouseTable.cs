using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoomRadar_Backend.Migrations
{
    /// <inheritdoc />
    public partial class BoardingHouseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoardingHouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Barangay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Municipality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rules = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumOfBeds = table.Column<int>(type: "int", nullable: false),
                    NumOfBedrooms = table.Column<int>(type: "int", nullable: false),
                    NumOfBathrooms = table.Column<int>(type: "int", nullable: false),
                    MonthlyRate = table.Column<double>(type: "float", nullable: false),
                    Location_Latitude = table.Column<double>(type: "float", nullable: true),
                    Location_Longitude = table.Column<double>(type: "float", nullable: true),
                    LandLordId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmenitiesJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowPets = table.Column<bool>(type: "bit", nullable: false),
                    AdditionalFees = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardingHouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardingHouses_Users_LandLordId",
                        column: x => x.LandLordId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardingHouses_LandLordId",
                table: "BoardingHouses",
                column: "LandLordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardingHouses");
        }
    }
}
