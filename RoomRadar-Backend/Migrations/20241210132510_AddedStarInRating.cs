using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoomRadar_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddedStarInRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Star",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Star",
                table: "Ratings");
        }
    }
}
