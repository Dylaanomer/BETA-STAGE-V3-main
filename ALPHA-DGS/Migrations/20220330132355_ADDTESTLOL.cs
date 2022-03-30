using Microsoft.EntityFrameworkCore.Migrations;

namespace ALPHA_DGS.Migrations
{
    public partial class ADDTESTLOL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MagazijnPartijId",
                table: "Magazijn",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Stadium3",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StadIum = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Omschrijving = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadium3", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Magazijn_MagazijnPartijId",
                table: "Magazijn",
                column: "MagazijnPartijId");

            migrationBuilder.AddForeignKey(
                name: "FK_Magazijn_MagazijnPartij_MagazijnPartijId",
                table: "Magazijn",
                column: "MagazijnPartijId",
                principalTable: "MagazijnPartij",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Magazijn_MagazijnPartij_MagazijnPartijId",
                table: "Magazijn");

            migrationBuilder.DropTable(
                name: "Stadium3");

            migrationBuilder.DropIndex(
                name: "IX_Magazijn_MagazijnPartijId",
                table: "Magazijn");

            migrationBuilder.DropColumn(
                name: "MagazijnPartijId",
                table: "Magazijn");
        }
    }
}
