using Microsoft.EntityFrameworkCore.Migrations;

namespace UserFinder.DataAccess.Migrations
{
    public partial class initialCreate15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSeen",
                table: "Apppointments",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSeen",
                table: "Apppointments");
        }
    }
}
