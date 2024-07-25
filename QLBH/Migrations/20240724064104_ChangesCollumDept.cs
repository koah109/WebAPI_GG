using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLBH.Migrations
{
    /// <inheritdoc />
    public partial class ChangesCollumDept : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DEPT_NUMBER",
                table: "DEPARTMENT",
                newName: "DEPT_NAME");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DEPT_NAME",
                table: "DEPARTMENT",
                newName: "DEPT_NUMBER");
        }
    }
}
