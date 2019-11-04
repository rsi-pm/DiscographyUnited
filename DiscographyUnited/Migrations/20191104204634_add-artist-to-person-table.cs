using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscographyUnited.Migrations
{
    public partial class addartisttopersontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PersonEntityId",
                table: "Award",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Award_PersonEntityId",
                table: "Award",
                column: "PersonEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Award_Person_PersonEntityId",
                table: "Award",
                column: "PersonEntityId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Award_Person_PersonEntityId",
                table: "Award");

            migrationBuilder.DropIndex(
                name: "IX_Award_PersonEntityId",
                table: "Award");

            migrationBuilder.DropColumn(
                name: "PersonEntityId",
                table: "Award");
        }
    }
}
