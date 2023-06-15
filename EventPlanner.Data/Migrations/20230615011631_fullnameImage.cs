using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPlanner.Data.Migrations
{
    /// <inheritdoc />
    public partial class fullnameImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fullname",
                table: "Feedback",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Feedback",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fullname",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Feedback");
        }
    }
}
