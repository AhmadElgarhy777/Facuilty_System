using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class edit_phone_col : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberPhones_Members_MemberId1",
                table: "MemberPhones");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentPhones_Students_StudentId1_StudentLevel",
                table: "StudentPhones");

            migrationBuilder.DropIndex(
                name: "IX_MemberPhones_MemberId1",
                table: "MemberPhones");

            migrationBuilder.DropColumn(
                name: "MemberId1",
                table: "MemberPhones");

            migrationBuilder.AlterColumn<int>(
                name: "StudentLevel",
                table: "StudentPhones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StudentId1",
                table: "StudentPhones",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "StudentPhones",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "MemberId",
                table: "MemberPhones",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_MemberPhones_MemberId",
                table: "MemberPhones",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberPhones_Members_MemberId",
                table: "MemberPhones",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPhones_Students_StudentId1_StudentLevel",
                table: "StudentPhones",
                columns: new[] { "StudentId1", "StudentLevel" },
                principalTable: "Students",
                principalColumns: new[] { "StudentId", "Level" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberPhones_Members_MemberId",
                table: "MemberPhones");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentPhones_Students_StudentId1_StudentLevel",
                table: "StudentPhones");

            migrationBuilder.DropIndex(
                name: "IX_MemberPhones_MemberId",
                table: "MemberPhones");

            migrationBuilder.AlterColumn<int>(
                name: "StudentLevel",
                table: "StudentPhones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId1",
                table: "StudentPhones",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentPhones",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "MemberPhones",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "MemberId1",
                table: "MemberPhones",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemberPhones_MemberId1",
                table: "MemberPhones",
                column: "MemberId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberPhones_Members_MemberId1",
                table: "MemberPhones",
                column: "MemberId1",
                principalTable: "Members",
                principalColumn: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPhones_Students_StudentId1_StudentLevel",
                table: "StudentPhones",
                columns: new[] { "StudentId1", "StudentLevel" },
                principalTable: "Students",
                principalColumns: new[] { "StudentId", "Level" });
        }
    }
}
