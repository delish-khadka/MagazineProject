using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagazineProject.Migrations
{
    /// <inheritdoc />
    public partial class RemovedImageFromDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Advertisement");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Advertisement",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
