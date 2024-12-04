using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Add_Models_col : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "degree",
                table: "StudentCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentId",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId1",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MemberId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId1",
                table: "Courses",
                column: "DepartmentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_MemberId",
                table: "Courses",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentId1",
                table: "Courses",
                column: "DepartmentId1",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Members_MemberId",
                table: "Courses",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentId1",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Members_MemberId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DepartmentId1",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_MemberId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "degree",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DepartmentId1",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Courses");
        }
    }
}
