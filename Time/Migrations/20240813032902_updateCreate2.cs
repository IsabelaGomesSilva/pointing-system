using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Time.Migrations
{
    /// <inheritdoc />
    public partial class updateCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectId1",
                table: "ProjectTasks");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId1",
                table: "ProjectTasks",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectId1",
                table: "ProjectTasks",
                column: "ProjectId1",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectId1",
                table: "ProjectTasks");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId1",
                table: "ProjectTasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectId1",
                table: "ProjectTasks",
                column: "ProjectId1",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
