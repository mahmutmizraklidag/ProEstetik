using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProEstetik.Web.Migrations
{
    /// <inheritdoc />
    public partial class titlehome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HomeTitle",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeTitle",
                table: "Services");
        }
    }
}
