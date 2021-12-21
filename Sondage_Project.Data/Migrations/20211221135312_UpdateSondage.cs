using Microsoft.EntityFrameworkCore.Migrations;

namespace Sondage_Project.Data.Migrations
{
    public partial class UpdateSondage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "box_1",
                table: "Sondages");

            migrationBuilder.DropColumn(
                name: "box_2",
                table: "Sondages");

            migrationBuilder.DropColumn(
                name: "box_3",
                table: "Sondages");

            migrationBuilder.DropColumn(
                name: "box_4",
                table: "Sondages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "box_1",
                table: "Sondages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "box_2",
                table: "Sondages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "box_3",
                table: "Sondages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "box_4",
                table: "Sondages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
