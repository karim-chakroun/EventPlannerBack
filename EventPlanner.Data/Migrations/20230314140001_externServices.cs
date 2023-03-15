using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPlanner.Data.Migrations
{
    /// <inheritdoc />
    public partial class externServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExternServices",
                columns: table => new
                {
                    IdExternServices = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    serviceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    provider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prix = table.Column<float>(type: "real", nullable: true),
                    avalable = table.Column<bool>(type: "bit", nullable: false),
                    EventFk = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternServices", x => x.IdExternServices);
                    table.ForeignKey(
                        name: "FK_ExternServices_Events_EventFk",
                        column: x => x.EventFk,
                        principalTable: "Events",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExternServices_EventFk",
                table: "ExternServices",
                column: "EventFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExternServices");
        }
    }
}
