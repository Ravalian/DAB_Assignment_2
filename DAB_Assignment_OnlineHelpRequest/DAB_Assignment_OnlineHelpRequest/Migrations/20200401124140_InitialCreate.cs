using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_Assignment_OnlineHelpRequest.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    courseId = table.Column<string>(nullable: false),
                    CourseName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.courseId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentAUid = table.Column<string>(nullable: false),
                    StudentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentAUid);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherAUid = table.Column<string>(nullable: false),
                    TeacherName = table.Column<string>(nullable: true),
                    courseId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherAUid);
                    table.ForeignKey(
                        name: "FK_Teachers_Courses_courseId",
                        column: x => x.courseId,
                        principalTable: "Courses",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attends",
                columns: table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    CourseId = table.Column<string>(nullable: false),
                    Semester = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attends", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_Attends_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attends_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentAUid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    lecture = table.Column<string>(nullable: false),
                    number = table.Column<string>(nullable: false),
                    helpwhere = table.Column<string>(nullable: true),
                    courseId = table.Column<string>(nullable: true),
                    TeacherAUid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => new { x.lecture, x.number });
                    table.ForeignKey(
                        name: "FK_Assignments_Teachers_TeacherAUid",
                        column: x => x.TeacherAUid,
                        principalTable: "Teachers",
                        principalColumn: "TeacherAUid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_Courses_courseId",
                        column: x => x.courseId,
                        principalTable: "Courses",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    lecture = table.Column<string>(nullable: false),
                    number = table.Column<string>(nullable: false),
                    helpwhere = table.Column<string>(nullable: true),
                    StudentAUid = table.Column<string>(nullable: true),
                    courseId = table.Column<string>(nullable: true),
                    TeacherAUid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => new { x.lecture, x.number });
                    table.ForeignKey(
                        name: "FK_Exercise_Students_StudentAUid",
                        column: x => x.StudentAUid,
                        principalTable: "Students",
                        principalColumn: "StudentAUid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercise_Teachers_TeacherAUid",
                        column: x => x.TeacherAUid,
                        principalTable: "Teachers",
                        principalColumn: "TeacherAUid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercise_Courses_courseId",
                        column: x => x.courseId,
                        principalTable: "Courses",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestHelpAssignments",
                columns: table => new
                {
                    RequestHelpAssignmentID = table.Column<string>(nullable: false),
                    StudentName = table.Column<string>(nullable: true),
                    StudentId = table.Column<string>(nullable: true),
                    AssignmentLecture = table.Column<string>(nullable: true),
                    AssignmentNumber = table.Column<string>(nullable: true),
                    AssignmentHelpWhere = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestHelpAssignments", x => x.RequestHelpAssignmentID);
                    table.ForeignKey(
                        name: "FK_RequestHelpAssignments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentAUid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestHelpAssignments_Assignments_AssignmentLecture_AssignmentNumber",
                        columns: x => new { x.AssignmentLecture, x.AssignmentNumber },
                        principalTable: "Assignments",
                        principalColumns: new[] { "lecture", "number" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TeacherAUid",
                table: "Assignments",
                column: "TeacherAUid");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_courseId",
                table: "Assignments",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_Attends_CourseId",
                table: "Attends",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_StudentAUid",
                table: "Exercise",
                column: "StudentAUid");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_TeacherAUid",
                table: "Exercise",
                column: "TeacherAUid");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_courseId",
                table: "Exercise",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestHelpAssignments_StudentId",
                table: "RequestHelpAssignments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestHelpAssignments_AssignmentLecture_AssignmentNumber",
                table: "RequestHelpAssignments",
                columns: new[] { "AssignmentLecture", "AssignmentNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_courseId",
                table: "Teachers",
                column: "courseId");
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
                name: "Students");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
