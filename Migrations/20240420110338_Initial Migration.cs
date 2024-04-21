using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeriodicTableTutor.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LatinName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AtomicNumber = table.Column<int>(type: "int", nullable: false),
                    MassNumber = table.Column<int>(type: "int", nullable: false),
                    YearOfDiscover = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Protons = table.Column<int>(type: "int", nullable: false),
                    Neutrons = table.Column<int>(type: "int", nullable: false),
                    Density = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elements");
        }
    }
}
