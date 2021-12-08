using Microsoft.EntityFrameworkCore.Migrations;

namespace Sondage_Project.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActivated",
                table: "Sondages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MultipleAnswer",
                table: "Sondages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActivated",
                table: "Sondages");

            migrationBuilder.DropColumn(
                name: "MultipleAnswer",
                table: "Sondages");
        }
    }
}
