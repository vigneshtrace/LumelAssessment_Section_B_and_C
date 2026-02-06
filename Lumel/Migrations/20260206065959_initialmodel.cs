using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lumel.Migrations
{
    /// <inheritdoc />
    public partial class initialmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "deliveryLog",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    driverId = table.Column<int>(type: "INTEGER", nullable: false),
                    deliveryStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    attemptDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deliveryLog", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "deliveryLog");
        }
    }
}
