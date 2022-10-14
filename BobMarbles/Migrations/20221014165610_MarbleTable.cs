using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BobMarbles.Migrations
{
    public partial class MarbleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marbles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(38,17)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marbles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marbles");
        }
    }
}
