using Microsoft.EntityFrameworkCore.Migrations;

namespace Assessment.Migrations
{
    public partial class CreateAboutInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Infos_PersonId",
                table: "Infos",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Infos_Persons_PersonId",
                table: "Infos",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "UUID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Infos_Persons_PersonId",
                table: "Infos");

            migrationBuilder.DropIndex(
                name: "IX_Infos_PersonId",
                table: "Infos");
        }
    }
}
