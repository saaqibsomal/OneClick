using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneClick.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName_NameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "HomePage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "HomePage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
