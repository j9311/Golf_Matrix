using Microsoft.EntityFrameworkCore.Migrations;

namespace GolfMatrix.Data.Migrations
{
    public partial class initset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseLength = table.Column<int>(type: "int", nullable: false),
                    TournamentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelSGTLs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrassType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Par5Count = table.Column<int>(type: "int", nullable: false),
                    Par4Count = table.Column<int>(type: "int", nullable: false),
                    Par3Count = table.Column<int>(type: "int", nullable: false),
                    CourseNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outcomes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseTop6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseMap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeatherConsiderations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatSheet = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
