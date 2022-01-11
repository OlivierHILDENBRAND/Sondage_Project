using Microsoft.EntityFrameworkCore.Migrations;

namespace Sondage_Project.Data.Migrations
{
    public partial class UpdateSondageDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sondages",
                columns: table => new
                {
                    SondageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Answer_1 = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Answer_2 = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Answer_3 = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Answer_4 = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Counter_1 = table.Column<int>(type: "int", nullable: false),
                    Counter_2 = table.Column<int>(type: "int", nullable: false),
                    Counter_3 = table.Column<int>(type: "int", nullable: false),
                    Counter_4 = table.Column<int>(type: "int", nullable: false),
                    answer1check = table.Column<bool>(type: "bit", nullable: false),
                    answer2check = table.Column<bool>(type: "bit", nullable: false),
                    answer3check = table.Column<bool>(type: "bit", nullable: false),
                    answer4check = table.Column<bool>(type: "bit", nullable: false),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    MultipleAnswer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sondages", x => x.SondageId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sondages");
        }
    }
}
