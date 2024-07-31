using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLBH.Migrations
{
    /// <inheritdoc />
    public partial class AddTableData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                columns: table => new
                {
                    CUST_CODE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PHONE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATER = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.CUST_CODE);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENT",
                columns: table => new
                {
                    DEPT_CODE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DEPT_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENT", x => x.DEPT_CODE);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE",
                columns: table => new
                {
                    EMP_CODE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMP_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSITION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HIRE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATER = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE", x => x.EMP_CODE);
                });

            migrationBuilder.CreateTable(
                name: "WAREHOUSE",
                columns: table => new
                {
                    WH_CODE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WH_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOCATION = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAREHOUSE", x => x.WH_CODE);
                });

            migrationBuilder.CreateTable(
                name: "ORDERS",
                columns: table => new
                {
                    ORDER_NO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORDER_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DEPT_CODE = table.Column<int>(type: "int", nullable: false),
                    CUST_CODE = table.Column<int>(type: "int", nullable: false),
                    CUST_SUB_NO = table.Column<int>(type: "int", nullable: false),
                    EMP_CODE = table.Column<int>(type: "int", nullable: false),
                    REQUIRED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CUSTORDER_NO = table.Column<int>(type: "int", nullable: false),
                    WH_CODE = table.Column<int>(type: "int", nullable: false),
                    CMP_TAX = table.Column<int>(type: "int", nullable: false),
                    SLIP_COMMENT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATER = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.ORDER_NO);
                    table.ForeignKey(
                        name: "FK_ORDERS_CUSTOMER_CUST_CODE",
                        column: x => x.CUST_CODE,
                        principalTable: "CUSTOMER",
                        principalColumn: "CUST_CODE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDERS_DEPARTMENT_DEPT_CODE",
                        column: x => x.DEPT_CODE,
                        principalTable: "DEPARTMENT",
                        principalColumn: "DEPT_CODE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDERS_EMPLOYEE_EMP_CODE",
                        column: x => x.EMP_CODE,
                        principalTable: "EMPLOYEE",
                        principalColumn: "EMP_CODE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDERS_WAREHOUSE_WH_CODE",
                        column: x => x.WH_CODE,
                        principalTable: "WAREHOUSE",
                        principalColumn: "WH_CODE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT",
                columns: table => new
                {
                    PROD_CODE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROD_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UNITPRICE = table.Column<float>(type: "real", nullable: false),
                    STOCK_QTY = table.Column<int>(type: "int", nullable: false),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WH_CODE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.PROD_CODE);
                    table.ForeignKey(
                        name: "FK_PRODUCT_WAREHOUSE_WH_CODE",
                        column: x => x.WH_CODE,
                        principalTable: "WAREHOUSE",
                        principalColumn: "WH_CODE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_DETAILS",
                columns: table => new
                {
                    SO_ROW_NO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORDER_NO = table.Column<int>(type: "int", nullable: false),
                    PROD_CODE = table.Column<int>(type: "int", nullable: false),
                    PROD_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UNITPRICE = table.Column<float>(type: "real", nullable: false),
                    QUANTITY = table.Column<int>(type: "int", nullable: false),
                    CMP_TAX_RATE = table.Column<float>(type: "real", nullable: false),
                    RESERVE_QTY = table.Column<int>(type: "int", nullable: false),
                    DELIVERY_ORDER_QTY = table.Column<int>(type: "int", nullable: false),
                    DELIVERED_QTY = table.Column<int>(type: "int", nullable: false),
                    COMPLETE_FLG = table.Column<int>(type: "int", nullable: false),
                    DISCOUNT = table.Column<float>(type: "real", nullable: false),
                    DELIVERY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATER = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_DETAILS", x => x.SO_ROW_NO);
                    table.ForeignKey(
                        name: "FK_ORDER_DETAILS_ORDERS_ORDER_NO",
                        column: x => x.ORDER_NO,
                        principalTable: "ORDERS",
                        principalColumn: "ORDER_NO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_DETAILS_PRODUCT_PROD_CODE",
                        column: x => x.PROD_CODE,
                        principalTable: "PRODUCT",
                        principalColumn: "PROD_CODE",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_DETAILS_ORDER_NO",
                table: "ORDER_DETAILS",
                column: "ORDER_NO");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_DETAILS_PROD_CODE",
                table: "ORDER_DETAILS",
                column: "PROD_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_CUST_CODE",
                table: "ORDERS",
                column: "CUST_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_DEPT_CODE",
                table: "ORDERS",
                column: "DEPT_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_EMP_CODE",
                table: "ORDERS",
                column: "EMP_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_WH_CODE",
                table: "ORDERS",
                column: "WH_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_WH_CODE",
                table: "PRODUCT",
                column: "WH_CODE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ORDER_DETAILS");

            migrationBuilder.DropTable(
                name: "ORDERS");

            migrationBuilder.DropTable(
                name: "PRODUCT");

            migrationBuilder.DropTable(
                name: "CUSTOMER");

            migrationBuilder.DropTable(
                name: "DEPARTMENT");

            migrationBuilder.DropTable(
                name: "EMPLOYEE");

            migrationBuilder.DropTable(
                name: "WAREHOUSE");
        }
    }
}
