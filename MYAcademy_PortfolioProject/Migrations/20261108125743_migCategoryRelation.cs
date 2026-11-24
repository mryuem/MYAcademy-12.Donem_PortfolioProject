using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MYAcademy_PortfolioProject.Migrations
{
    /// <inheritdoc />
    public partial class migCategoryRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Experiences");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Experiences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_CategoryId",
                table: "Experiences",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Categories_CategoryId",
                table: "Experiences",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Categories_CategoryId",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_CategoryId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Experiences");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Experiences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
