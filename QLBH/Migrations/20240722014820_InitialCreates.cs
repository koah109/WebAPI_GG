using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLBH.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WH_code",
                table: "ORDERS",
                newName: "WH_CODE");

            migrationBuilder.RenameColumn(
                name: "Updater",
                table: "ORDERS",
                newName: "UPDATER");

            migrationBuilder.RenameColumn(
                name: "Update_date",
                table: "ORDERS",
                newName: "UPDATE_DATE");

            migrationBuilder.RenameColumn(
                name: "Slip_comment",
                table: "ORDERS",
                newName: "SLIP_COMMENT");

            migrationBuilder.RenameColumn(
                name: "Required_date",
                table: "ORDERS",
                newName: "REQUIRED_DATE");

            migrationBuilder.RenameColumn(
                name: "Order_date",
                table: "ORDERS",
                newName: "ORDER_DATE");

            migrationBuilder.RenameColumn(
                name: "Emp_code",
                table: "ORDERS",
                newName: "EMP_CODE");

            migrationBuilder.RenameColumn(
                name: "Dept_code",
                table: "ORDERS",
                newName: "DEPT_CODE");

            migrationBuilder.RenameColumn(
                name: "Custorder_no",
                table: "ORDERS",
                newName: "CUSTORDER_NO");

            migrationBuilder.RenameColumn(
                name: "Cust_sub_no",
                table: "ORDERS",
                newName: "CUST_SUB_NO");

            migrationBuilder.RenameColumn(
                name: "Cust_code",
                table: "ORDERS",
                newName: "CUST_CODE");

            migrationBuilder.RenameColumn(
                name: "CMP_tax",
                table: "ORDERS",
                newName: "CMP_TAX");

            migrationBuilder.RenameColumn(
                name: "Order_no",
                table: "ORDERS",
                newName: "ORDER_NO");

            migrationBuilder.RenameColumn(
                name: "Updater",
                table: "EMPLOYEE",
                newName: "UPDATER");

            migrationBuilder.RenameColumn(
                name: "Update_date",
                table: "EMPLOYEE",
                newName: "UPDATE_DATE");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "EMPLOYEE",
                newName: "POSITION");

            migrationBuilder.RenameColumn(
                name: "Hire_date",
                table: "EMPLOYEE",
                newName: "HIRE_DATE");

            migrationBuilder.RenameColumn(
                name: "Emp_name",
                table: "EMPLOYEE",
                newName: "EMP_NAME");

            migrationBuilder.RenameColumn(
                name: "Dept_code",
                table: "EMPLOYEE",
                newName: "DEPT_CODE");

            migrationBuilder.RenameColumn(
                name: "Emp_code",
                table: "EMPLOYEE",
                newName: "EMP_CODE");

            migrationBuilder.RenameColumn(
                name: "Updater",
                table: "CUSTOMER",
                newName: "UPDATER");

            migrationBuilder.RenameColumn(
                name: "Update_date",
                table: "CUSTOMER",
                newName: "UPDATE_DATE");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "CUSTOMER",
                newName: "PHONE");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "CUSTOMER",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "CUSTOMER",
                newName: "ADDRESS");

            migrationBuilder.RenameColumn(
                name: "Cust_code",
                table: "CUSTOMER",
                newName: "CUST_CODE");

            migrationBuilder.RenameColumn(
                name: "CUST_NAME123",
                table: "CUSTOMER",
                newName: "CUST_NAME");

            migrationBuilder.AlterColumn<float>(
                name: "UNITPRICE",
                table: "PRODUCT",
                type: "real",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WH_CODE",
                table: "ORDERS",
                newName: "WH_code");

            migrationBuilder.RenameColumn(
                name: "UPDATE_DATE",
                table: "ORDERS",
                newName: "Update_date");

            migrationBuilder.RenameColumn(
                name: "UPDATER",
                table: "ORDERS",
                newName: "Updater");

            migrationBuilder.RenameColumn(
                name: "SLIP_COMMENT",
                table: "ORDERS",
                newName: "Slip_comment");

            migrationBuilder.RenameColumn(
                name: "REQUIRED_DATE",
                table: "ORDERS",
                newName: "Required_date");

            migrationBuilder.RenameColumn(
                name: "ORDER_DATE",
                table: "ORDERS",
                newName: "Order_date");

            migrationBuilder.RenameColumn(
                name: "EMP_CODE",
                table: "ORDERS",
                newName: "Emp_code");

            migrationBuilder.RenameColumn(
                name: "DEPT_CODE",
                table: "ORDERS",
                newName: "Dept_code");

            migrationBuilder.RenameColumn(
                name: "CUST_SUB_NO",
                table: "ORDERS",
                newName: "Cust_sub_no");

            migrationBuilder.RenameColumn(
                name: "CUST_CODE",
                table: "ORDERS",
                newName: "Cust_code");

            migrationBuilder.RenameColumn(
                name: "CUSTORDER_NO",
                table: "ORDERS",
                newName: "Custorder_no");

            migrationBuilder.RenameColumn(
                name: "CMP_TAX",
                table: "ORDERS",
                newName: "CMP_tax");

            migrationBuilder.RenameColumn(
                name: "ORDER_NO",
                table: "ORDERS",
                newName: "Order_no");

            migrationBuilder.RenameColumn(
                name: "UPDATE_DATE",
                table: "EMPLOYEE",
                newName: "Update_date");

            migrationBuilder.RenameColumn(
                name: "UPDATER",
                table: "EMPLOYEE",
                newName: "Updater");

            migrationBuilder.RenameColumn(
                name: "POSITION",
                table: "EMPLOYEE",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "HIRE_DATE",
                table: "EMPLOYEE",
                newName: "Hire_date");

            migrationBuilder.RenameColumn(
                name: "EMP_NAME",
                table: "EMPLOYEE",
                newName: "Emp_name");

            migrationBuilder.RenameColumn(
                name: "DEPT_CODE",
                table: "EMPLOYEE",
                newName: "Dept_code");

            migrationBuilder.RenameColumn(
                name: "EMP_CODE",
                table: "EMPLOYEE",
                newName: "Emp_code");

            migrationBuilder.RenameColumn(
                name: "UPDATE_DATE",
                table: "CUSTOMER",
                newName: "Update_date");

            migrationBuilder.RenameColumn(
                name: "UPDATER",
                table: "CUSTOMER",
                newName: "Updater");

            migrationBuilder.RenameColumn(
                name: "PHONE",
                table: "CUSTOMER",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "CUSTOMER",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "ADDRESS",
                table: "CUSTOMER",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "CUST_CODE",
                table: "CUSTOMER",
                newName: "Cust_code");

            migrationBuilder.RenameColumn(
                name: "CUST_NAME",
                table: "CUSTOMER",
                newName: "CUST_NAME123");

            migrationBuilder.AlterColumn<decimal>(
                name: "UNITPRICE",
                table: "PRODUCT",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);
        }
    }
}
