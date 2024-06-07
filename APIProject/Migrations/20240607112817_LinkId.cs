using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProject.Migrations
{
    public partial class LinkId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Interests_InterestId",
                table: "Links");

            migrationBuilder.AlterColumn<int>(
                name: "InterestId",
                table: "Links",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Interests_InterestId",
                table: "Links",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "InterestId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Interests_InterestId",
                table: "Links");

            migrationBuilder.AlterColumn<int>(
                name: "InterestId",
                table: "Links",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Interests_InterestId",
                table: "Links",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "InterestId");
        }
    }
}
