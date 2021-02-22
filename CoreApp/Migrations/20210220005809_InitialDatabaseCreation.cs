using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreApp.Migrations
{
    public partial class InitialDatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentName = table.Column<string>(nullable: false),
                    GitHubUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentId);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    LevelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.LevelId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Grade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "AssignmentId", "AssignmentName", "GitHubUrl" },
                values: new object[] { 1, "Assignment 6.1", "Test Url" });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "LevelId", "Name" },
                values: new object[,]
                {
                    { 9, "Level9" },
                    { 8, "Level8" },
                    { 7, "Level7" },
                    { 6, "Level6" },
                    { 10, "Level10" },
                    { 4, "Level4" },
                    { 3, "Level3" },
                    { 2, "Level2" },
                    { 1, "Level1" },
                    { 5, "Level5" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "Grade", "LastName" },
                values: new object[,]
                {
                    { 9, "Justin", 72, "Smith" },
                    { 1, "John", 92, "Doe" },
                    { 2, "Sally", 79, "Johnson" },
                    { 3, "Jim", 88, "Fredrick" },
                    { 4, "Carrie", 69, "Smith" },
                    { 5, "Larry", 96, "Fisher" },
                    { 6, "Fred", 84, "Doe" },
                    { 7, "Kelly", 76, "Johnson" },
                    { 8, "Wendy", 91, "Fredrick" },
                    { 10, "Peytyn", 94, "Fisher" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
