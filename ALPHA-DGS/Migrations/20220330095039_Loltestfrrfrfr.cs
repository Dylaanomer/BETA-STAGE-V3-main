using Microsoft.EntityFrameworkCore.Migrations;

namespace ALPHA_DGS.Migrations
{
    public partial class Loltestfrrfrfr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MagazijnPartij_Magazijn_MagazijnId",
                table: "MagazijnPartij");

            migrationBuilder.DropForeignKey(
                name: "FK_MagazijnPartij_Partijserie_PserId",
                table: "MagazijnPartij");

            migrationBuilder.DropForeignKey(
                name: "FK_MagazijnPartij_Stadium_StadiumId",
                table: "MagazijnPartij");

            migrationBuilder.AddForeignKey(
                name: "FK_MagazijnPartij_Magazijn_MagazijnId",
                table: "MagazijnPartij",
                column: "MagazijnId",
                principalTable: "Magazijn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MagazijnPartij_Partijserie_PserId",
                table: "MagazijnPartij",
                column: "PserId",
                principalTable: "Partijserie",
                principalColumn: "PserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MagazijnPartij_Stadium_StadiumId",
                table: "MagazijnPartij",
                column: "StadiumId",
                principalTable: "Stadium",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MagazijnPartij_Magazijn_MagazijnId",
                table: "MagazijnPartij");

            migrationBuilder.DropForeignKey(
                name: "FK_MagazijnPartij_Partijserie_PserId",
                table: "MagazijnPartij");

            migrationBuilder.DropForeignKey(
                name: "FK_MagazijnPartij_Stadium_StadiumId",
                table: "MagazijnPartij");

            migrationBuilder.AddForeignKey(
                name: "FK_MagazijnPartij_Magazijn_MagazijnId",
                table: "MagazijnPartij",
                column: "MagazijnId",
                principalTable: "Magazijn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MagazijnPartij_Partijserie_PserId",
                table: "MagazijnPartij",
                column: "PserId",
                principalTable: "Partijserie",
                principalColumn: "PserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MagazijnPartij_Stadium_StadiumId",
                table: "MagazijnPartij",
                column: "StadiumId",
                principalTable: "Stadium",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
