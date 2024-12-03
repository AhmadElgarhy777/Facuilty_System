using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Adding_Schema : Migration
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
                name: "UserModel");

            migrationBuilder.EnsureSchema(
                name: "Securty");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Students",
                newSchema: "UserModel");

            migrationBuilder.RenameTable(
                name: "StudentPhones",
                newName: "StudentPhones",
                newSchema: "UserModel");

            migrationBuilder.RenameTable(
                name: "StudentCourses",
                newName: "StudentCourses",
                newSchema: "UserModel");

            migrationBuilder.RenameTable(
                name: "Sections",
                newName: "Sections",
                newSchema: "UserModel");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Members",
                newSchema: "UserModel");

            migrationBuilder.RenameTable(
                name: "MemberPhones",
                newName: "MemberPhones",
                newSchema: "UserModel");

            migrationBuilder.RenameTable(
                name: "Lectures",
                newName: "Lectures",
                newSchema: "UserModel");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employees",
                newSchema: "UserModel");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Departments",
                newSchema: "UserModel");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Courses",
                newSchema: "UserModel");

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
                name: "Students",
                schema: "UserModel",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "StudentPhones",
                schema: "UserModel",
                newName: "StudentPhones");

            migrationBuilder.RenameTable(
                name: "StudentCourses",
                schema: "UserModel",
                newName: "StudentCourses");

            migrationBuilder.RenameTable(
                name: "Sections",
                schema: "UserModel",
                newName: "Sections");

            migrationBuilder.RenameTable(
                name: "Members",
                schema: "UserModel",
                newName: "Members");

            migrationBuilder.RenameTable(
                name: "MemberPhones",
                schema: "UserModel",
                newName: "MemberPhones");

            migrationBuilder.RenameTable(
                name: "Lectures",
                schema: "UserModel",
                newName: "Lectures");

            migrationBuilder.RenameTable(
                name: "Employees",
                schema: "UserModel",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "Departments",
                schema: "UserModel",
                newName: "Departments");

            migrationBuilder.RenameTable(
                name: "Courses",
                schema: "UserModel",
                newName: "Courses");

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
