using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB_Assignment_OnlineHelpRequest.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Isactive",
                table: "RequestHelpAssignments",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Isactive",
                table: "RequestHelpAssignments");
        }
    }
}
