using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagazineProject.Migrations
{
    /// <inheritdoc />
    public partial class AddedImageToJournal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Journal",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Journal");
        }
    }
}
