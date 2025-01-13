using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Time.Migrations
{
    /// <inheritdoc />
    public partial class updateCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBillable",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "IsGlobal",
                table: "ProjectTasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBillable",
                table: "ProjectTasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsGlobal",
                table: "ProjectTasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
