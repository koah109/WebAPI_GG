using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLBH.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                columns: table => new
                {
                    Cust_code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUST_NAME123 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updater = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.Cust_code);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE",
                columns: table => new
                {
                    Emp_code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dept_code = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hire_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updater = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE", x => x.Emp_code);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_DETAILS",
                columns: table => new
                {
                    SO_ROW_NO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORDER_NO = table.Column<int>(type: "int", nullable: true),
                    PROD_CODE = table.Column<int>(type: "int", nullable: true),
                    PROD_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UNITPRICE = table.Column<float>(type: "real", nullable: true),
                    QUANTITY = table.Column<int>(type: "int", nullable: true),
                    CMP_TAX_RATE = table.Column<float>(type: "real", nullable: true),
                    RESERVE_QTY = table.Column<int>(type: "int", nullable: true),
                    DELIVERY_ORDER_QTY = table.Column<int>(type: "int", nullable: true),
                    DELIVERED_QTY = table.Column<int>(type: "int", nullable: true),
                    COMPLETE_FLG = table.Column<int>(type: "int", nullable: true),
                    DISCOUNT = table.Column<float>(type: "real", nullable: true),
                    DELIVERY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATER = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_DETAILS", x => x.SO_ROW_NO);
                });

            migrationBuilder.CreateTable(
                name: "ORDERS",
                columns: table => new
                {
                    Order_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dept_code = table.Column<int>(type: "int", nullable: false),
                    Cust_code = table.Column<int>(type: "int", nullable: false),
                    Cust_sub_no = table.Column<int>(type: "int", nullable: false),
                    Emp_code = table.Column<int>(type: "int", nullable: false),
                    Required_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Custorder_no = table.Column<int>(type: "int", nullable: false),
                    WH_code = table.Column<int>(type: "int", nullable: false),
                    CMP_tax = table.Column<int>(type: "int", nullable: false),
                    Slip_comment = table.Column<int>(type: "int", nullable: false),
                    Update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updater = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.Order_no);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT",
                columns: table => new
                {
                    PROD_CODE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROD_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UNITPRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    STOCK_QTY = table.Column<int>(type: "int", nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WH_CODE = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.PROD_CODE);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CUSTOMER");

            migrationBuilder.DropTable(
                name: "EMPLOYEE");

            migrationBuilder.DropTable(
                name: "ORDER_DETAILS");

            migrationBuilder.DropTable(
                name: "ORDERS");

            migrationBuilder.DropTable(
                name: "PRODUCT");
        }
    }
}
