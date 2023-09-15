using Microsoft.EntityFrameworkCore.Migrations;

namespace UserFinder.DataAccess.Migrations
{
    public partial class initialCreate13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Worktimes",
                table: "Doctors",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionFromDoctor",
                table: "Apppointments",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Apppointments",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Worktimes",
                table: "Doctors");

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionFromDoctor",
                table: "Apppointments",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Apppointments",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 300,
                oldNullable: true);
        }
    }
}
