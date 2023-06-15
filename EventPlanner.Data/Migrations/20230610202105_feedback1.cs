using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPlanner.Data.Migrations
{
    /// <inheritdoc />
    public partial class feedback1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    IdFeedback = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePost = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPoster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdReceiver = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.IdFeedback);
                    table.ForeignKey(
                        name: "FK_Feedback_AspNetUsers_IdReceiver",
                        column: x => x.IdReceiver,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_IdReceiver",
                table: "Feedback",
                column: "IdReceiver");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");
        }
    }
}
