using Microsoft.EntityFrameworkCore.Migrations;

namespace ALPHA_DGS.Migrations
{
    public partial class Lolnowfr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PserId",
                table: "MagazijnPartij",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MagazijnPartij_PserId",
                table: "MagazijnPartij",
                column: "PserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MagazijnPartij_Partijserie_PserId",
                table: "MagazijnPartij",
                column: "PserId",
                principalTable: "Partijserie",
                principalColumn: "PserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MagazijnPartij_Partijserie_PserId",
                table: "MagazijnPartij");

            migrationBuilder.DropIndex(
                name: "IX_MagazijnPartij_PserId",
                table: "MagazijnPartij");

            migrationBuilder.DropColumn(
                name: "PserId",
                table: "MagazijnPartij");
        }
    }
}
