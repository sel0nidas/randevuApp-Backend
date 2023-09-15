using Microsoft.EntityFrameworkCore.Migrations;

namespace UserFinder.DataAccess.Migrations
{
    public partial class initialCreate61 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorType",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoctorType",
                table: "Users",
                maxLength: 50,
                nullable: true);
        }
    }
}
