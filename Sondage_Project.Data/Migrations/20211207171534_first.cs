using Microsoft.EntityFrameworkCore.Migrations;

namespace Sondage_Project.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sondages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descriptif = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Question_1 = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Question_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question_4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sondages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sondages");
        }
    }
}
