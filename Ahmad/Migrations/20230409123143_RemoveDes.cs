using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ahmad.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Dragons");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Dragons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
