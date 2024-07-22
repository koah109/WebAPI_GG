using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLBH.Migrations
{
    /// <inheritdoc />
    public partial class addforeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_WH_CODE",
                table: "PRODUCT",
                column: "WH_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_CUST_CODE",
                table: "ORDERS",
                column: "CUST_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_EMP_CODE",
                table: "ORDERS",
                column: "EMP_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_WH_CODE",
                table: "ORDERS",
                column: "WH_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_DETAILS_ORDER_NO",
                table: "ORDER_DETAILS",
                column: "ORDER_NO");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_DETAILS_PROD_CODE",
                table: "ORDER_DETAILS",
                column: "PROD_CODE");

            migrationBuilder.AddForeignKey(
                name: "FK_ORDER_DETAILS_ORDERS_ORDER_NO",
                table: "ORDER_DETAILS",
                column: "ORDER_NO",
                principalTable: "ORDERS",
                principalColumn: "ORDER_NO");

            migrationBuilder.AddForeignKey(
                name: "FK_ORDER_DETAILS_PRODUCT_PROD_CODE",
                table: "ORDER_DETAILS",
                column: "PROD_CODE",
                principalTable: "PRODUCT",
                principalColumn: "PROD_CODE");

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERS_CUSTOMER_CUST_CODE",
                table: "ORDERS",
                column: "CUST_CODE",
                principalTable: "CUSTOMER",
                principalColumn: "CUST_CODE",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERS_EMPLOYEE_EMP_CODE",
                table: "ORDERS",
                column: "EMP_CODE",
                principalTable: "EMPLOYEE",
                principalColumn: "EMP_CODE",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERS_WAREHOUSE_WH_CODE",
                table: "ORDERS",
                column: "WH_CODE",
                principalTable: "WAREHOUSE",
                principalColumn: "WH_CODE",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT_WAREHOUSE_WH_CODE",
                table: "PRODUCT",
                column: "WH_CODE",
                principalTable: "WAREHOUSE",
                principalColumn: "WH_CODE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ORDER_DETAILS_ORDERS_ORDER_NO",
                table: "ORDER_DETAILS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDER_DETAILS_PRODUCT_PROD_CODE",
                table: "ORDER_DETAILS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDERS_CUSTOMER_CUST_CODE",
                table: "ORDERS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDERS_EMPLOYEE_EMP_CODE",
                table: "ORDERS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDERS_WAREHOUSE_WH_CODE",
                table: "ORDERS");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_WAREHOUSE_WH_CODE",
                table: "PRODUCT");

            migrationBuilder.DropIndex(
                name: "IX_PRODUCT_WH_CODE",
                table: "PRODUCT");

            migrationBuilder.DropIndex(
                name: "IX_ORDERS_CUST_CODE",
                table: "ORDERS");

            migrationBuilder.DropIndex(
                name: "IX_ORDERS_EMP_CODE",
                table: "ORDERS");

            migrationBuilder.DropIndex(
                name: "IX_ORDERS_WH_CODE",
                table: "ORDERS");

            migrationBuilder.DropIndex(
                name: "IX_ORDER_DETAILS_ORDER_NO",
                table: "ORDER_DETAILS");

            migrationBuilder.DropIndex(
                name: "IX_ORDER_DETAILS_PROD_CODE",
                table: "ORDER_DETAILS");
        }
    }
}
