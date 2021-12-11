using Microsoft.EntityFrameworkCore.Migrations;

namespace Sondage_Project.Data.Migrations
{
    public partial class AddCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "counter_1",
                table: "Sondages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "counter_2",
                table: "Sondages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "counter_3",
                table: "Sondages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "counter_4",
                table: "Sondages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "counter_1",
                table: "Sondages");

            migrationBuilder.DropColumn(
                name: "counter_2",
                table: "Sondages");

            migrationBuilder.DropColumn(
                name: "counter_3",
                table: "Sondages");

            migrationBuilder.DropColumn(
                name: "counter_4",
                table: "Sondages");
        }
    }
}
