using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FanSite.EntityFramework.Services.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "media_series",
                columns: table => new
                {
                    ms_id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ms_title = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_media_series", x => x.ms_id);
                });

            migrationBuilder.CreateTable(
                name: "media_type",
                columns: table => new
                {
                    mt_id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mt_name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_media_type", x => x.mt_id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    rl_id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rl_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.rl_id);
                });

            migrationBuilder.CreateTable(
                name: "media",
                columns: table => new
                {
                    md_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    md_title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    md_publication_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    md_description = table.Column<string>(type: "ntext", nullable: false),
                    md_rating = table.Column<double>(type: "float", nullable: false),
                    md_is_upcoming = table.Column<bool>(type: "bit", nullable: false),
                    md_type = table.Column<byte>(type: "tinyint", nullable: false),
                    md_series_id = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_media", x => x.md_id);
                    table.ForeignKey(
                        name: "FK_media_media_series_md_series_id",
                        column: x => x.md_series_id,
                        principalTable: "media_series",
                        principalColumn: "ms_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_media_media_type_md_type",
                        column: x => x.md_type,
                        principalTable: "media_type",
                        principalColumn: "mt_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    us_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    us_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    us_password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    us_email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    us_role = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.us_id);
                    table.ForeignKey(
                        name: "FK_user_role_us_role",
                        column: x => x.us_role,
                        principalTable: "role",
                        principalColumn: "rl_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    cm_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cm_text = table.Column<string>(type: "ntext", nullable: false),
                    cm_publication_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    cm_media_id = table.Column<int>(type: "int", nullable: false),
                    cm_user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => new { x.cm_id, x.cm_media_id, x.cm_user_id });
                    table.ForeignKey(
                        name: "FK_comment_media_cm_media_id",
                        column: x => x.cm_media_id,
                        principalTable: "media",
                        principalColumn: "md_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comment_user_cm_user_id",
                        column: x => x.cm_user_id,
                        principalTable: "user",
                        principalColumn: "us_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_id",
                table: "comment",
                column: "cm_id");

            migrationBuilder.CreateIndex(
                name: "IX_media_id",
                table: "comment",
                column: "cm_media_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_id",
                table: "comment",
                column: "cm_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_series_id",
                table: "media",
                column: "md_series_id");

            migrationBuilder.CreateIndex(
                name: "IX_type_id",
                table: "media",
                column: "md_type");

            migrationBuilder.CreateIndex(
                name: "IX_email",
                table: "user",
                column: "us_email");

            migrationBuilder.CreateIndex(
                name: "IX_role_id",
                table: "user",
                column: "us_role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "media");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "media_series");

            migrationBuilder.DropTable(
                name: "media_type");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
