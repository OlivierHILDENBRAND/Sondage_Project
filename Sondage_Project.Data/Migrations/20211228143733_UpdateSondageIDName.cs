using Microsoft.EntityFrameworkCore.Migrations;

namespace Sondage_Project.Data.Migrations
{
    public partial class UpdateSondageIDName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sondages",
                newName: "SondageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SondageId",
                table: "Sondages",
                newName: "Id");
        }
    }
}
