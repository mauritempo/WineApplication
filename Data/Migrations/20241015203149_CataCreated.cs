using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CataCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Invitados = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CataWines",
                columns: table => new
                {
                    CatasId = table.Column<int>(type: "INTEGER", nullable: false),
                    VinosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CataWines", x => new { x.CatasId, x.VinosId });
                    table.ForeignKey(
                        name: "FK_CataWines_Catas_CatasId",
                        column: x => x.CatasId,
                        principalTable: "Catas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CataWines_Wines_VinosId",
                        column: x => x.VinosId,
                        principalTable: "Wines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CataWines_VinosId",
                table: "CataWines",
                column: "VinosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CataWines");

            migrationBuilder.DropTable(
                name: "Catas");
        }
    }
}
