using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoomRadar_Backend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLandLordCredential : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LandLordCredentials_UserProfileId",
                table: "LandLordCredentials");

            migrationBuilder.CreateIndex(
                name: "IX_LandLordCredentials_UserProfileId",
                table: "LandLordCredentials",
                column: "UserProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LandLordCredentials_UserProfileId",
                table: "LandLordCredentials");

            migrationBuilder.CreateIndex(
                name: "IX_LandLordCredentials_UserProfileId",
                table: "LandLordCredentials",
                column: "UserProfileId",
                unique: true);
        }
    }
}
