using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FanSite.EntityFramework.Services.Migrations
{
    public partial class ChangeSeriesAttributeToGetVirtProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_media_media_series_md_series_id",
                table: "media");

            migrationBuilder.RenameColumn(
                name: "md_series_id",
                table: "media",
                newName: "md_series");

            migrationBuilder.AddForeignKey(
                name: "FK_media_media_series_md_series",
                table: "media",
                column: "md_series",
                principalTable: "media_series",
                principalColumn: "ms_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_media_media_series_md_series",
                table: "media");

            migrationBuilder.RenameColumn(
                name: "md_series",
                table: "media",
                newName: "md_series_id");

            migrationBuilder.AddForeignKey(
                name: "FK_media_media_series_md_series_id",
                table: "media",
                column: "md_series_id",
                principalTable: "media_series",
                principalColumn: "ms_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
