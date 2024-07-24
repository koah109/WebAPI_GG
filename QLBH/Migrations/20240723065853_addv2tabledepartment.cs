using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLBH.Migrations
{
    /// <inheritdoc />
    public partial class addv2tabledepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_DEPT_CODE",
                table: "ORDERS",
                column: "DEPT_CODE");

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERS_DEPARTMENT_DEPT_CODE",
                table: "ORDERS",
                column: "DEPT_CODE",
                principalTable: "DEPARTMENT",
                principalColumn: "DEPT_CODE",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ORDERS_DEPARTMENT_DEPT_CODE",
                table: "ORDERS");

            migrationBuilder.DropIndex(
                name: "IX_ORDERS_DEPT_CODE",
                table: "ORDERS");
        }
    }
}
