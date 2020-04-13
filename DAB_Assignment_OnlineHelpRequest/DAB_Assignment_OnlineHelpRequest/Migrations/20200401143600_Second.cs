using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_Assignment_OnlineHelpRequest.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Students_StudentAUid",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Teachers_TeacherAUid",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Courses_courseId",
                table: "Exercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise");

            migrationBuilder.RenameTable(
                name: "Exercise",
                newName: "Exercises");

            migrationBuilder.RenameIndex(
                name: "IX_Exercise_courseId",
                table: "Exercises",
                newName: "IX_Exercises_courseId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercise_TeacherAUid",
                table: "Exercises",
                newName: "IX_Exercises_TeacherAUid");

            migrationBuilder.RenameIndex(
                name: "IX_Exercise_StudentAUid",
                table: "Exercises",
                newName: "IX_Exercises_StudentAUid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                columns: new[] { "lecture", "number" });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Students_StudentAUid",
                table: "Exercises",
                column: "StudentAUid",
                principalTable: "Students",
                principalColumn: "StudentAUid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Teachers_TeacherAUid",
                table: "Exercises",
                column: "TeacherAUid",
                principalTable: "Teachers",
                principalColumn: "TeacherAUid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Courses_courseId",
                table: "Exercises",
                column: "courseId",
                principalTable: "Courses",
                principalColumn: "courseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Students_StudentAUid",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Teachers_TeacherAUid",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Courses_courseId",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "Exercise");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_courseId",
                table: "Exercise",
                newName: "IX_Exercise_courseId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_TeacherAUid",
                table: "Exercise",
                newName: "IX_Exercise_TeacherAUid");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_StudentAUid",
                table: "Exercise",
                newName: "IX_Exercise_StudentAUid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise",
                columns: new[] { "lecture", "number" });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Students_StudentAUid",
                table: "Exercise",
                column: "StudentAUid",
                principalTable: "Students",
                principalColumn: "StudentAUid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Teachers_TeacherAUid",
                table: "Exercise",
                column: "TeacherAUid",
                principalTable: "Teachers",
                principalColumn: "TeacherAUid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Courses_courseId",
                table: "Exercise",
                column: "courseId",
                principalTable: "Courses",
                principalColumn: "courseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
