using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoomRadar_Backend.Migrations
{
    /// <inheritdoc />
    public partial class DeletedLandLordCredential : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LandLordCredentials");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LandLordCredentials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandLordCredentials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandLordCredentials_Profiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LandLordCredentials_UserProfileId",
                table: "LandLordCredentials",
                column: "UserProfileId");
        }
    }
}
