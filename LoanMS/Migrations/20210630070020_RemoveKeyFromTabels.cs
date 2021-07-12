using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanMS.Migrations
{
    public partial class RemoveKeyFromTabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalLoans",
                table: "PersonalLoans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EducationLoans",
                table: "EducationLoans");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "PersonalLoans",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "LoanId",
                table: "PersonalLoans",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "EducationLoans",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "LoanId",
                table: "EducationLoans",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalLoans",
                table: "PersonalLoans",
                column: "LoanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EducationLoans",
                table: "EducationLoans",
                column: "LoanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalLoans",
                table: "PersonalLoans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EducationLoans",
                table: "EducationLoans");

            migrationBuilder.DropColumn(
                name: "LoanId",
                table: "PersonalLoans");

            migrationBuilder.DropColumn(
                name: "LoanId",
                table: "EducationLoans");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "PersonalLoans",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "EducationLoans",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalLoans",
                table: "PersonalLoans",
                column: "CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EducationLoans",
                table: "EducationLoans",
                column: "CustomerId");
        }
    }
}
