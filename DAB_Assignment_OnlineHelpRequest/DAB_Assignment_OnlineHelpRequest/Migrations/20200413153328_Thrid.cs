using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_Assignment_OnlineHelpRequest.Migrations
{
    public partial class Thrid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestHelpAssignments_Students_StudentId",
                table: "RequestHelpAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestHelpAssignments_Assignments_AssignmentLecture_AssignmentNumber",
                table: "RequestHelpAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestHelpAssignments",
                table: "RequestHelpAssignments");

            migrationBuilder.DropIndex(
                name: "IX_RequestHelpAssignments_AssignmentLecture_AssignmentNumber",
                table: "RequestHelpAssignments");

            migrationBuilder.DropColumn(
                name: "RequestHelpAssignmentID",
                table: "RequestHelpAssignments");

            migrationBuilder.DropColumn(
                name: "AssignmentHelpWhere",
                table: "RequestHelpAssignments");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "RequestHelpAssignments");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "RequestHelpAssignments",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AssignmentNumber",
                table: "RequestHelpAssignments",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AssignmentLecture",
                table: "RequestHelpAssignments",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestHelpAssignments",
                table: "RequestHelpAssignments",
                columns: new[] { "AssignmentLecture", "AssignmentNumber", "StudentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RequestHelpAssignments_Students_StudentId",
                table: "RequestHelpAssignments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentAUid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestHelpAssignments_Assignments_AssignmentLecture_AssignmentNumber",
                table: "RequestHelpAssignments",
                columns: new[] { "AssignmentLecture", "AssignmentNumber" },
                principalTable: "Assignments",
                principalColumns: new[] { "lecture", "number" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestHelpAssignments_Students_StudentId",
                table: "RequestHelpAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestHelpAssignments_Assignments_AssignmentLecture_AssignmentNumber",
                table: "RequestHelpAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestHelpAssignments",
                table: "RequestHelpAssignments");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "RequestHelpAssignments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "AssignmentNumber",
                table: "RequestHelpAssignments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "AssignmentLecture",
                table: "RequestHelpAssignments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "RequestHelpAssignmentID",
                table: "RequestHelpAssignments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AssignmentHelpWhere",
                table: "RequestHelpAssignments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "RequestHelpAssignments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestHelpAssignments",
                table: "RequestHelpAssignments",
                column: "RequestHelpAssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestHelpAssignments_AssignmentLecture_AssignmentNumber",
                table: "RequestHelpAssignments",
                columns: new[] { "AssignmentLecture", "AssignmentNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_RequestHelpAssignments_Students_StudentId",
                table: "RequestHelpAssignments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentAUid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestHelpAssignments_Assignments_AssignmentLecture_AssignmentNumber",
                table: "RequestHelpAssignments",
                columns: new[] { "AssignmentLecture", "AssignmentNumber" },
                principalTable: "Assignments",
                principalColumns: new[] { "lecture", "number" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
