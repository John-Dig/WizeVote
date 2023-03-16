using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vote.Migrations
{
    public partial class ChoiceId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChoiceId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ChoiceId",
                table: "Users",
                column: "ChoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Choices_ChoiceId",
                table: "Users",
                column: "ChoiceId",
                principalTable: "Choices",
                principalColumn: "ChoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Choices_ChoiceId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ChoiceId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ChoiceId",
                table: "Users");
        }
    }
}
