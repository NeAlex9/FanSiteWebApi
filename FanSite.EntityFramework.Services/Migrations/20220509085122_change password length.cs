using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FanSite.EntityFramework.Services.Migrations
{
    public partial class changepasswordlength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "us_password",
                table: "user",
                type: "nvarchar(73)",
                maxLength: 73,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "us_password",
                table: "user",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(73)",
                oldMaxLength: 73);
        }
    }
}
