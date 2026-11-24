using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MYAcademy_PortfolioProject.Migrations
{
    /// <inheritdoc />
    public partial class mig10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectItems",
                columns: table => new
                {
                    ProjectItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectItemTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectItems", x => x.ProjectItemId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectProjectItem",
                columns: table => new
                {
                    ProjectItemsProjectItemId = table.Column<int>(type: "int", nullable: false),
                    ProjectsProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectProjectItem", x => new { x.ProjectItemsProjectItemId, x.ProjectsProjectId });
                    table.ForeignKey(
                        name: "FK_ProjectProjectItem_ProjectItems_ProjectItemsProjectItemId",
                        column: x => x.ProjectItemsProjectItemId,
                        principalTable: "ProjectItems",
                        principalColumn: "ProjectItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectProjectItem_Projects_ProjectsProjectId",
                        column: x => x.ProjectsProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProjectItem_ProjectsProjectId",
                table: "ProjectProjectItem",
                column: "ProjectsProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectProjectItem");

            migrationBuilder.DropTable(
                name: "ProjectItems");
        }
    }
}
