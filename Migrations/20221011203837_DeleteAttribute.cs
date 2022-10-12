using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharp_boolflix.Migrations
{
    public partial class DeleteAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_MediaInfos_MediaInfoId",
                table: "Episodes");

            migrationBuilder.DropIndex(
                name: "IX_Episodes_MediaInfoId",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "MediaInfoId",
                table: "Episodes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MediaInfoId",
                table: "Episodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_MediaInfoId",
                table: "Episodes",
                column: "MediaInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_MediaInfos_MediaInfoId",
                table: "Episodes",
                column: "MediaInfoId",
                principalTable: "MediaInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
