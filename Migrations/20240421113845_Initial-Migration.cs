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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    LatinName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Protons = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Neutrons = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Electrons = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    AtomicMass = table.Column<double>(type: "float", nullable: false),
                    MassNumber = table.Column<int>(type: "int", nullable: false),
                    Density = table.Column<double>(type: "float", nullable: false),
                    Phase = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", maxLength: 24, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Discoverer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Id);
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
