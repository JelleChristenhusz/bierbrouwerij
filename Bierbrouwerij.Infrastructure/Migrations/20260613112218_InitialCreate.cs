using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bierbrouwerij.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bieren",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false),
                    Beschrijving = table.Column<string>(type: "TEXT", nullable: false),
                    Alcoholpercentage = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bieren", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredienten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Hoeveelheid = table.Column<double>(type: "REAL", nullable: false),
                    BierId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredienten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredienten_Bieren_BierId",
                        column: x => x.BierId,
                        principalTable: "Bieren",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bieren",
                columns: new[] { "Id", "Alcoholpercentage", "Beschrijving", "Naam" },
                values: new object[,]
                {
                    { 1, 8.4000000000000004, "Een fruitig Belgisch tripelbier", "Tripel Karmeliet" },
                    { 2, 7.0, "Een donker abdijbier met karamelsmaken", "Westmalle Dubbel" },
                    { 3, 5.0, "Een fris en licht lagerbier", "Heineken" }
                });

            migrationBuilder.InsertData(
                table: "Ingredienten",
                columns: new[] { "Id", "BierId", "Hoeveelheid", "Naam", "Type" },
                values: new object[,]
                {
                    { 1, 1, 4.5, "Pilsnermout", "Mout" },
                    { 2, 1, 30.0, "Saaz", "Hop" },
                    { 3, 1, 1.5, "Tarwe", "Graan" },
                    { 4, 1, 0.5, "Belgische gist", "Gist" },
                    { 5, 2, 5.0, "Karamelizmout", "Mout" },
                    { 6, 2, 25.0, "Hallertau", "Hop" },
                    { 7, 2, 0.5, "Abdijgist", "Gist" },
                    { 8, 3, 3.5, "Pale Ale Mout", "Mout" },
                    { 9, 3, 20.0, "Cascade", "Hop" },
                    { 10, 3, 0.5, "Lagergist", "Gist" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredienten_BierId",
                table: "Ingredienten",
                column: "BierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredienten");

            migrationBuilder.DropTable(
                name: "Bieren");
        }
    }
}
