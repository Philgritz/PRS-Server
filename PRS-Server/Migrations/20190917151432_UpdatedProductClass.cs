using Microsoft.EntityFrameworkCore.Migrations;

namespace PRS_Server.Migrations
{
    public partial class UpdatedProductClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "Products",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "PhotoPath",
                table: "Products",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 255);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Unit",
                table: "Products",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "PhotoPath",
                table: "Products",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}
