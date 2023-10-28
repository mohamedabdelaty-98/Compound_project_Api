using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Compound_project.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_units_buildings_BuildingId",
                table: "units");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingId",
                table: "units",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_units_buildings_BuildingId",
                table: "units",
                column: "BuildingId",
                principalTable: "buildings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_units_buildings_BuildingId",
                table: "units");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingId",
                table: "units",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_units_buildings_BuildingId",
                table: "units",
                column: "BuildingId",
                principalTable: "buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
