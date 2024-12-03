using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Adding_Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CourseLevel = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hourse = table.Column<int>(type: "int", nullable: false),
                    Degree = table.Column<int>(type: "int", nullable: false),
                    DocumentUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => new { x.CourseId, x.CourseLevel });
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumOfStudent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumOfCourses = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    LecturesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LecURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CourseLevel = table.Column<int>(type: "int", nullable: false),
                    CourseId1 = table.Column<int>(type: "int", nullable: false),
                    CourseLevel1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.LecturesID);
                    table.ForeignKey(
                        name: "FK_Lectures_Courses_CourseId1_CourseLevel1",
                        columns: x => new { x.CourseId1, x.CourseLevel1 },
                        principalTable: "Courses",
                        principalColumns: new[] { "CourseId", "CourseLevel" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CourseLevel = table.Column<int>(type: "int", nullable: false),
                    CourseId1 = table.Column<int>(type: "int", nullable: false),
                    CourseLevel1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionsID);
                    table.ForeignKey(
                        name: "FK_Sections_Courses_CourseId1_CourseLevel1",
                        columns: x => new { x.CourseId1, x.CourseLevel1 },
                        principalTable: "Courses",
                        principalColumns: new[] { "CourseId", "CourseLevel" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "[FName] + ' ' + [MName] + ' ' + [LName]"),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationailty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "[FName] + ' ' + [MName] + ' ' + [LName]"),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationailty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Experence = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    MName = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "[FName] + ' ' + [MName] + ' ' + [LName]"),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationailty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => new { x.StudentId, x.Level });
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberPhones",
                columns: table => new
                {
                    MemberPhoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberPhones", x => x.MemberPhoneId);
                    table.ForeignKey(
                        name: "FK_MemberPhones_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CourseLevel = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.CourseId, x.CourseLevel, x.StudentId, x.Level });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId_CourseLevel",
                        columns: x => new { x.CourseId, x.CourseLevel },
                        principalTable: "Courses",
                        principalColumns: new[] { "CourseId", "CourseLevel" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId_Level",
                        columns: x => new { x.StudentId, x.Level },
                        principalTable: "Students",
                        principalColumns: new[] { "StudentId", "Level" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentPhones",
                columns: table => new
                {
                    StudentPhoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId1 = table.Column<int>(type: "int", nullable: false),
                    StudentLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPhones", x => x.StudentPhoneId);
                    table.ForeignKey(
                        name: "FK_StudentPhones_Students_StudentId1_StudentLevel",
                        columns: x => new { x.StudentId1, x.StudentLevel },
                        principalTable: "Students",
                        principalColumns: new[] { "StudentId", "Level" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_CourseId1_CourseLevel1",
                table: "Lectures",
                columns: new[] { "CourseId1", "CourseLevel1" });

            migrationBuilder.CreateIndex(
                name: "IX_MemberPhones_MemberId",
                table: "MemberPhones",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_DepartmentId",
                table: "Members",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CourseId1_CourseLevel1",
                table: "Sections",
                columns: new[] { "CourseId1", "CourseLevel1" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId_Level",
                table: "StudentCourses",
                columns: new[] { "StudentId", "Level" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentPhones_StudentId1_StudentLevel",
                table: "StudentPhones",
                columns: new[] { "StudentId1", "StudentLevel" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "MemberPhones");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "StudentPhones");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
