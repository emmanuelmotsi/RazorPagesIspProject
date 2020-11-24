using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesIspProject.Migrations
{
    public partial class InitalUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicant",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Forename = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    IdentityNumber = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhysicalAddress = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetail", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: true),
                    CompanyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainBusiness = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PhysicalAddress = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    DateOfIncorporation = table.Column<DateTime>(nullable: true),
                    ApplicantID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Company_Applicant_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "Applicant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactDetailID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employee_ContactDetail_ContactDetailID",
                        column: x => x.ContactDetailID,
                        principalTable: "ContactDetail",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Occupation = table.Column<string>(nullable: true),
                    SharesTaken = table.Column<int>(nullable: true),
                    Contribution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CashValue = table.Column<decimal>(type: "money", nullable: true),
                    SharePercentage = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    ContactDetailID = table.Column<int>(nullable: false),
                    CompanyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Member_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_ContactDetail_ContactDetailID",
                        column: x => x.ContactDetailID,
                        principalTable: "ContactDetail",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NameOption",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CompanyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NameOption", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NameOption_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyEmployee",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyEmployee", x => new { x.CompanyID, x.EmployeeID });
                    table.ForeignKey(
                        name: "FK_CompanyEmployee_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyEmployee_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyMember",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false),
                    MemberID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyMember", x => new { x.CompanyID, x.MemberID });
                    table.ForeignKey(
                        name: "FK_CompanyMember_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyMember_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_ApplicantID",
                table: "Company",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEmployee_EmployeeID",
                table: "CompanyEmployee",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMember_MemberID",
                table: "CompanyMember",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ContactDetailID",
                table: "Employee",
                column: "ContactDetailID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_CompanyID",
                table: "Member",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Member_ContactDetailID",
                table: "Member",
                column: "ContactDetailID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NameOption_CompanyID",
                table: "NameOption",
                column: "CompanyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyEmployee");

            migrationBuilder.DropTable(
                name: "CompanyMember");

            migrationBuilder.DropTable(
                name: "NameOption");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "ContactDetail");

            migrationBuilder.DropTable(
                name: "Applicant");
        }
    }
}
