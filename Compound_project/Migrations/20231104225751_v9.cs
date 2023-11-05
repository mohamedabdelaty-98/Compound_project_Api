using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Compound_project.Migrations
{
    /// <inheritdoc />
    public partial class v9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_AspNetUsers_UserId",
                table: "reviews");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "reviews",
                newName: "UserId020");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_UserId",
                table: "reviews",
                newName: "IX_reviews_UserId020");

            migrationBuilder.AddColumn<string>(
                name: "IConName",
                table: "services",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "landMarksCompounds",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "landmarks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_AspNetUsers_UserId020",
                table: "reviews",
                column: "UserId020",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_AspNetUsers_UserId020",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "IConName",
                table: "services");

            migrationBuilder.RenameColumn(
                name: "UserId020",
                table: "reviews",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_UserId020",
                table: "reviews",
                newName: "IX_reviews_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "landMarksCompounds",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "landmarks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_AspNetUsers_UserId",
                table: "reviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
