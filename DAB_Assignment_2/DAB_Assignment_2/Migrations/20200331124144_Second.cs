using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_Assignment_2.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    lecture = table.Column<string>(nullable: false),
                    number = table.Column<int>(nullable: false),
                    helpwhere = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => new { x.lecture, x.number });
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    courseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.courseId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentAUid = table.Column<string>(nullable: false),
                    StudentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentAUid);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    TeacherAUid = table.Column<string>(nullable: false),
                    TeacherName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.TeacherAUid);
                });

            migrationBuilder.CreateTable(
                name: "Attends",
                columns: table => new
                {
                    Semester = table.Column<string>(nullable: false),
                    StudentId = table.Column<string>(nullable: true),
                    StudentName = table.Column<string>(nullable: true),
                    CourseName = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attends", x => x.Semester);
                    table.ForeignKey(
                        name: "FK_Attends_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attends_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentAUid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    lecture = table.Column<string>(nullable: false),
                    number = table.Column<int>(nullable: false),
                    helpwhere = table.Column<string>(nullable: true),
                    StudentAUid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => new { x.lecture, x.number });
                    table.ForeignKey(
                        name: "FK_Exercise_Student_StudentAUid",
                        column: x => x.StudentAUid,
                        principalTable: "Student",
                        principalColumn: "StudentAUid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestHelpAssignments",
                columns: table => new
                {
                    RequestHelpAssignmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(nullable: true),
                    StudentId = table.Column<string>(nullable: true),
                    AssignmentLecture = table.Column<string>(nullable: true),
                    AssignmentNumber = table.Column<int>(nullable: false),
                    AssignmentHelpWhere = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestHelpAssignments", x => x.RequestHelpAssignmentID);
                    table.ForeignKey(
                        name: "FK_RequestHelpAssignments_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentAUid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestHelpAssignments_Assignment_AssignmentLecture_AssignmentNumber",
                        columns: x => new { x.AssignmentLecture, x.AssignmentNumber },
                        principalTable: "Assignment",
                        principalColumns: new[] { "lecture", "number" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attends_CourseId",
                table: "Attends",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Attends_StudentId",
                table: "Attends",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_StudentAUid",
                table: "Exercise",
                column: "StudentAUid");

            migrationBuilder.CreateIndex(
                name: "IX_RequestHelpAssignments_StudentId",
                table: "RequestHelpAssignments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestHelpAssignments_AssignmentLecture_AssignmentNumber",
                table: "RequestHelpAssignments",
                columns: new[] { "AssignmentLecture", "AssignmentNumber" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attends");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "RequestHelpAssignments");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Assignment");
        }
    }
}
