using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneClick.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName_NameChangeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HomePage",
                table: "HomePage");

            migrationBuilder.RenameTable(
                name: "HomePage",
                newName: "CMS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CMS",
                table: "CMS",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CMS",
                table: "CMS");

            migrationBuilder.RenameTable(
                name: "CMS",
                newName: "HomePage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomePage",
                table: "HomePage",
                column: "Id");
        }
    }
}
