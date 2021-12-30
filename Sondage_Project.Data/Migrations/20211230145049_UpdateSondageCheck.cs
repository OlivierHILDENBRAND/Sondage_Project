using Microsoft.EntityFrameworkCore.Migrations;

namespace Sondage_Project.Data.Migrations
{
    public partial class UpdateSondageCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "answer1check",
                table: "Sondages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "answer2check",
                table: "Sondages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "answer3check",
                table: "Sondages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "answer4check",
                table: "Sondages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "answer1check",
                table: "Sondages");

            migrationBuilder.DropColumn(
                name: "answer2check",
                table: "Sondages");

            migrationBuilder.DropColumn(
                name: "answer3check",
                table: "Sondages");

            migrationBuilder.DropColumn(
                name: "answer4check",
                table: "Sondages");
        }
    }
}
