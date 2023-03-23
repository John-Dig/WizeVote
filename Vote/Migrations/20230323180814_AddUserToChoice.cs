using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vote.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToChoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "Description",
                keyValue: null,
                column: "Description",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Choices",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Choices",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_UserId",
                table: "Choices",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_AspNetUsers_UserId",
                table: "Choices",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_AspNetUsers_UserId",
                table: "Choices");

            migrationBuilder.DropIndex(
                name: "IX_Choices_UserId",
                table: "Choices");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Choices");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Choices",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
