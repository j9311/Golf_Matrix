using Microsoft.EntityFrameworkCore.Migrations;

namespace GolfMatrix.Data.Migrations
{
    public partial class par : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Par",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Par",
                table: "Course");
        }
    }
}
