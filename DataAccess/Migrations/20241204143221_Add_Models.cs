using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Add_Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.EnsureSchema(
                name: "Securty");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "IdentityUserToken",
                newSchema: "Securty");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "IdentityUser",
                newSchema: "Securty");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "IdentityUserRole",
                newSchema: "Securty");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "IdentityUserLogin",
                newSchema: "Securty");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "IdentityUserClaim",
                newSchema: "Securty");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "IdentityRole",
                newSchema: "Securty");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "IdentityRoleClaim",
                newSchema: "Securty");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "Securty",
                table: "IdentityUserRole",
                newName: "IX_IdentityUserRole_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "Securty",
                table: "IdentityUserLogin",
                newName: "IX_IdentityUserLogin_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "Securty",
                table: "IdentityUserClaim",
                newName: "IX_IdentityUserClaim_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "Securty",
                table: "IdentityRoleClaim",
                newName: "IX_IdentityRoleClaim_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserToken",
                schema: "Securty",
                table: "IdentityUserToken",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUser",
                schema: "Securty",
                table: "IdentityUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserRole",
                schema: "Securty",
                table: "IdentityUserRole",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserLogin",
                schema: "Securty",
                table: "IdentityUserLogin",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserClaim",
                schema: "Securty",
                table: "IdentityUserClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityRole",
                schema: "Securty",
                table: "IdentityRole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityRoleClaim",
                schema: "Securty",
                table: "IdentityRoleClaim",
                column: "Id");

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
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SSN = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    MName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    MemberId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SSN = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    MName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SSN = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    MName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberPhones", x => x.MemberPhoneId);
                    table.ForeignKey(
                        name: "FK_MemberPhones_Members_MemberId1",
                        column: x => x.MemberId1,
                        principalTable: "Members",
                        principalColumn: "MemberId");
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CourseLevel = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    StudentId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StudentLevel = table.Column<int>(type: "int", nullable: true),
                    CourseId1 = table.Column<int>(type: "int", nullable: false),
                    CourseLevel1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.CourseId, x.CourseLevel, x.StudentId, x.Level });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId1_CourseLevel1",
                        columns: x => new { x.CourseId1, x.CourseLevel1 },
                        principalTable: "Courses",
                        principalColumns: new[] { "CourseId", "CourseLevel" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId1_StudentLevel",
                        columns: x => new { x.StudentId1, x.StudentLevel },
                        principalTable: "Students",
                        principalColumns: new[] { "StudentId", "Level" });
                });

            migrationBuilder.CreateTable(
                name: "StudentPhones",
                columns: table => new
                {
                    StudentPhoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StudentLevel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPhones", x => x.StudentPhoneId);
                    table.ForeignKey(
                        name: "FK_StudentPhones_Students_StudentId1_StudentLevel",
                        columns: x => new { x.StudentId1, x.StudentLevel },
                        principalTable: "Students",
                        principalColumns: new[] { "StudentId", "Level" });
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
                name: "IX_MemberPhones_MemberId1",
                table: "MemberPhones",
                column: "MemberId1");

            migrationBuilder.CreateIndex(
                name: "IX_Members_DepartmentId",
                table: "Members",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CourseId1_CourseLevel1",
                table: "Sections",
                columns: new[] { "CourseId1", "CourseLevel1" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId1_CourseLevel1",
                table: "StudentCourses",
                columns: new[] { "CourseId1", "CourseLevel1" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId1_StudentLevel",
                table: "StudentCourses",
                columns: new[] { "StudentId1", "StudentLevel" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentPhones_StudentId1_StudentLevel",
                table: "StudentPhones",
                columns: new[] { "StudentId1", "StudentLevel" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim_IdentityRole_RoleId",
                schema: "Securty",
                table: "IdentityRoleClaim",
                column: "RoleId",
                principalSchema: "Securty",
                principalTable: "IdentityRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim_IdentityUser_UserId",
                schema: "Securty",
                table: "IdentityUserClaim",
                column: "UserId",
                principalSchema: "Securty",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin_IdentityUser_UserId",
                schema: "Securty",
                table: "IdentityUserLogin",
                column: "UserId",
                principalSchema: "Securty",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole_IdentityRole_RoleId",
                schema: "Securty",
                table: "IdentityUserRole",
                column: "RoleId",
                principalSchema: "Securty",
                principalTable: "IdentityRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole_IdentityUser_UserId",
                schema: "Securty",
                table: "IdentityUserRole",
                column: "UserId",
                principalSchema: "Securty",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserToken_IdentityUser_UserId",
                schema: "Securty",
                table: "IdentityUserToken",
                column: "UserId",
                principalSchema: "Securty",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityRoleClaim_IdentityRole_RoleId",
                schema: "Securty",
                table: "IdentityRoleClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserClaim_IdentityUser_UserId",
                schema: "Securty",
                table: "IdentityUserClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserLogin_IdentityUser_UserId",
                schema: "Securty",
                table: "IdentityUserLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole_IdentityRole_RoleId",
                schema: "Securty",
                table: "IdentityUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole_IdentityUser_UserId",
                schema: "Securty",
                table: "IdentityUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserToken_IdentityUser_UserId",
                schema: "Securty",
                table: "IdentityUserToken");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserToken",
                schema: "Securty",
                table: "IdentityUserToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserRole",
                schema: "Securty",
                table: "IdentityUserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserLogin",
                schema: "Securty",
                table: "IdentityUserLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserClaim",
                schema: "Securty",
                table: "IdentityUserClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUser",
                schema: "Securty",
                table: "IdentityUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityRoleClaim",
                schema: "Securty",
                table: "IdentityRoleClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityRole",
                schema: "Securty",
                table: "IdentityRole");

            migrationBuilder.RenameTable(
                name: "IdentityUserToken",
                schema: "Securty",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "IdentityUserRole",
                schema: "Securty",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "IdentityUserLogin",
                schema: "Securty",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "IdentityUserClaim",
                schema: "Securty",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "IdentityUser",
                schema: "Securty",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "IdentityRoleClaim",
                schema: "Securty",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "IdentityRole",
                schema: "Securty",
                newName: "AspNetRoles");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUserRole_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUserLogin_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUserClaim_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityRoleClaim_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
