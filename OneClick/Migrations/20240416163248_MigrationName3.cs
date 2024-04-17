using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneClick.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomePage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header_Slider_Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Click_Header_Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Header_Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Highlights = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video_Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePage", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomePage");
        }
    }
}
