using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Compound_project.Migrations
{
    /// <inheritdoc />
    public partial class v8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_serviceBuildings_services_ServiceId",
                table: "serviceBuildings");

            migrationBuilder.DropForeignKey(
                name: "FK_servicesCompounds_services_ServiceId",
                table: "servicesCompounds");

            migrationBuilder.DropForeignKey(
                name: "FK_serviceUnits_services_ServiceId",
                table: "serviceUnits");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "serviceUnits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "servicesCompounds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "serviceBuildings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "compounds",
                type: "nvarchar(150)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_serviceBuildings_services_ServiceId",
                table: "serviceBuildings",
                column: "ServiceId",
                principalTable: "services",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_servicesCompounds_services_ServiceId",
                table: "servicesCompounds",
                column: "ServiceId",
                principalTable: "services",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_serviceUnits_services_ServiceId",
                table: "serviceUnits",
                column: "ServiceId",
                principalTable: "services",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_serviceBuildings_services_ServiceId",
                table: "serviceBuildings");

            migrationBuilder.DropForeignKey(
                name: "FK_servicesCompounds_services_ServiceId",
                table: "servicesCompounds");

            migrationBuilder.DropForeignKey(
                name: "FK_serviceUnits_services_ServiceId",
                table: "serviceUnits");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "compounds");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "serviceUnits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "servicesCompounds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "serviceBuildings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_serviceBuildings_services_ServiceId",
                table: "serviceBuildings",
                column: "ServiceId",
                principalTable: "services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_servicesCompounds_services_ServiceId",
                table: "servicesCompounds",
                column: "ServiceId",
                principalTable: "services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_serviceUnits_services_ServiceId",
                table: "serviceUnits",
                column: "ServiceId",
                principalTable: "services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
