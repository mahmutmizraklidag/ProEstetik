using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProEstetik.Web.Migrations
{
    /// <inheritdoc />
    public partial class dımg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image2",
                table: "Services");
        }
    }
}
