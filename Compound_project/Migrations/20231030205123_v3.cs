using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Compound_project.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imageBuildings");

            migrationBuilder.DropTable(
                name: "ImageCompound");

            migrationBuilder.CreateTable(
                name: "BuildingImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingImages_buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompundImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompoundId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompundImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompundImages_compounds_CompoundId",
                        column: x => x.CompoundId,
                        principalTable: "compounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingImages_BuildingId",
                table: "BuildingImages",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_CompundImages_CompoundId",
                table: "CompundImages",
                column: "CompoundId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingImages");

            migrationBuilder.DropTable(
                name: "CompundImages");

            migrationBuilder.CreateTable(
                name: "imageBuildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imageBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_imageBuildings_buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageCompound",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompoundId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageCompound", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageCompound_compounds_CompoundId",
                        column: x => x.CompoundId,
                        principalTable: "compounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_imageBuildings_BuildingId",
                table: "imageBuildings",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageCompound_CompoundId",
                table: "ImageCompound",
                column: "CompoundId");
        }
    }
}
