using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagazineProject.Migrations
{
    /// <inheritdoc />
    public partial class AddedImageOnAdvertisement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Advertisement",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Advertisement");
        }
    }
}
