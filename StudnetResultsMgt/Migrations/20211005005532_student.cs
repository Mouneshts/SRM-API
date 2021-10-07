using Microsoft.EntityFrameworkCore.Migrations;

namespace SRM_API.Migrations
{
    public partial class student : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Courses_CourseId",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_Student_StudentId",
                table: "Result");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_Subjects_SubjectId",
                table: "Result");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Branch_BrId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Courses_CourseId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Semester_SemesterId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Branch_bId",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Courses_CourseId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Student_CourseId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_SemesterId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Result_StudentId",
                table: "Result");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branch",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "SemesterId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StId",
                table: "Result");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Result");

            migrationBuilder.RenameTable(
                name: "Branch",
                newName: "branch");

            migrationBuilder.RenameColumn(
                name: "cId",
                table: "Subjects",
                newName: "Semid");

            migrationBuilder.RenameColumn(
                name: "SemId",
                table: "Student",
                newName: "Semester");

            migrationBuilder.RenameColumn(
                name: "CoId",
                table: "Student",
                newName: "Cid");

            migrationBuilder.RenameColumn(
                name: "BrId",
                table: "Student",
                newName: "BId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_BrId",
                table: "Student",
                newName: "IX_Student_BId");

            migrationBuilder.RenameColumn(
                name: "SubId",
                table: "Result",
                newName: "SId");

            migrationBuilder.RenameIndex(
                name: "IX_Branch_CourseId",
                table: "branch",
                newName: "IX_branch_CourseId");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "Result",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_branch",
                table: "branch",
                column: "BId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Semid",
                table: "Subjects",
                column: "Semid");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Cid",
                table: "Student",
                column: "Cid");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Semester",
                table: "Student",
                column: "Semester");

            migrationBuilder.CreateIndex(
                name: "IX_Result_SId",
                table: "Result",
                column: "SId");

            migrationBuilder.AddForeignKey(
                name: "FK_branch_Courses_CourseId",
                table: "branch",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Student_SId",
                table: "Result",
                column: "SId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Subjects_SubjectId",
                table: "Result",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_branch_BId",
                table: "Student",
                column: "BId",
                principalTable: "branch",
                principalColumn: "BId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Courses_Cid",
                table: "Student",
                column: "Cid",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Semester_Semester",
                table: "Student",
                column: "Semester",
                principalTable: "Semester",
                principalColumn: "SemesterId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_branch_bId",
                table: "Subjects",
                column: "bId",
                principalTable: "branch",
                principalColumn: "BId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Courses_CourseId",
                table: "Subjects",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Semester_Semid",
                table: "Subjects",
                column: "Semid",
                principalTable: "Semester",
                principalColumn: "SemesterId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_branch_Courses_CourseId",
                table: "branch");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_Student_SId",
                table: "Result");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_Subjects_SubjectId",
                table: "Result");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_branch_BId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Courses_Cid",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Semester_Semester",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_branch_bId",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Courses_CourseId",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Semester_Semid",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_Semid",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Student_Cid",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_Semester",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Result_SId",
                table: "Result");

            migrationBuilder.DropPrimaryKey(
                name: "PK_branch",
                table: "branch");

            migrationBuilder.RenameTable(
                name: "branch",
                newName: "Branch");

            migrationBuilder.RenameColumn(
                name: "Semid",
                table: "Subjects",
                newName: "cId");

            migrationBuilder.RenameColumn(
                name: "Semester",
                table: "Student",
                newName: "SemId");

            migrationBuilder.RenameColumn(
                name: "Cid",
                table: "Student",
                newName: "CoId");

            migrationBuilder.RenameColumn(
                name: "BId",
                table: "Student",
                newName: "BrId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_BId",
                table: "Student",
                newName: "IX_Student_BrId");

            migrationBuilder.RenameColumn(
                name: "SId",
                table: "Result",
                newName: "SubId");

            migrationBuilder.RenameIndex(
                name: "IX_branch_CourseId",
                table: "Branch",
                newName: "IX_Branch_CourseId");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Subjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SemesterId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "Result",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StId",
                table: "Result",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Result",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branch",
                table: "Branch",
                column: "BId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_CourseId",
                table: "Student",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_SemesterId",
                table: "Student",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Result_StudentId",
                table: "Result",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Courses_CourseId",
                table: "Branch",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Student_StudentId",
                table: "Result",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Subjects_SubjectId",
                table: "Result",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Branch_BrId",
                table: "Student",
                column: "BrId",
                principalTable: "Branch",
                principalColumn: "BId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Courses_CourseId",
                table: "Student",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Semester_SemesterId",
                table: "Student",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "SemesterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Branch_bId",
                table: "Subjects",
                column: "bId",
                principalTable: "Branch",
                principalColumn: "BId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Courses_CourseId",
                table: "Subjects",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
