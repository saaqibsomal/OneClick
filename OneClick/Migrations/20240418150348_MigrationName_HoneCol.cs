using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneClick.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName_HoneCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Video_Path",
                table: "HomePage",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "Highlights",
                table: "HomePage",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Header_Slider_Path",
                table: "HomePage",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Header_Logo",
                table: "HomePage",
                newName: "Path");

            migrationBuilder.RenameColumn(
                name: "Click_Header_Logo",
                table: "HomePage",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "CreatedOn",
                table: "HomePage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "HomePage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "HomePage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "HomePage");

            migrationBuilder.DropColumn(
                name: "Desc",
                table: "HomePage");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "HomePage");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "HomePage",
                newName: "Video_Path");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "HomePage",
                newName: "Highlights");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "HomePage",
                newName: "Header_Slider_Path");

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "HomePage",
                newName: "Header_Logo");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "HomePage",
                newName: "Click_Header_Logo");
        }
    }
}
