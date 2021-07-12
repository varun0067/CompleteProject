using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanMS.Migrations
{
    public partial class LoanDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EducationLoans",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    LoanApplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoanIssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RateOfInterest = table.Column<int>(type: "int", nullable: false),
                    DurationOfLoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseFee = table.Column<long>(type: "bigint", nullable: false),
                    Course = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherTotalExperience = table.Column<int>(type: "int", nullable: false),
                    FatherExperienceInCurrentCompany = table.Column<int>(type: "int", nullable: false),
                    RationCardNumber = table.Column<long>(type: "bigint", nullable: false),
                    AnnualIncome = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLoans", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "PersonalLoans",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    LoanApplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoanIssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RateOfInterest = table.Column<int>(type: "int", nullable: false),
                    DurationOfLoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnualIncome = table.Column<long>(type: "bigint", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalExperience = table.Column<int>(type: "int", nullable: false),
                    ExperienceInCurrentCompany = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalLoans", x => x.CustomerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EducationLoans");

            migrationBuilder.DropTable(
                name: "PersonalLoans");
        }
    }
}
