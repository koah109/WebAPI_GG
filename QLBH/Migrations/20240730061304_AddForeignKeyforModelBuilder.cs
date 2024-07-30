using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLBH.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyforModelBuilder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ORDER_DETAILS_ORDERS_ORDER_NO",
                table: "ORDER_DETAILS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDER_DETAILS_PRODUCT_PROD_CODE",
                table: "ORDER_DETAILS");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_WAREHOUSE_WH_CODE",
                table: "PRODUCT");

            migrationBuilder.DropIndex(
                name: "IX_PRODUCT_WH_CODE",
                table: "PRODUCT");

            migrationBuilder.AlterColumn<int>(
                name: "WH_CODE",
                table: "WAREHOUSE",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "WH_CODE",
                table: "PRODUCT",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "UNITPRICE",
                table: "PRODUCT",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "STOCK_QTY",
                table: "PRODUCT",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "UNITPRICE",
                table: "ORDER_DETAILS",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RESERVE_QTY",
                table: "ORDER_DETAILS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITY",
                table: "ORDER_DETAILS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PROD_CODE",
                table: "ORDER_DETAILS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ORDER_NO",
                table: "ORDER_DETAILS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "DISCOUNT",
                table: "ORDER_DETAILS",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DELIVERY_ORDER_QTY",
                table: "ORDER_DETAILS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DELIVERED_QTY",
                table: "ORDER_DETAILS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "COMPLETE_FLG",
                table: "ORDER_DETAILS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "CMP_TAX_RATE",
                table: "ORDER_DETAILS",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "HIRE_DATE",
                table: "EMPLOYEE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATE_DATE",
                table: "CUSTOMER",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_ORDER_DETAILS_ORDERS_ORDER_NO",
                table: "ORDER_DETAILS",
                column: "ORDER_NO",
                principalTable: "ORDERS",
                principalColumn: "ORDER_NO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDER_DETAILS_PRODUCT_PROD_CODE",
                table: "ORDER_DETAILS",
                column: "PROD_CODE",
                principalTable: "PRODUCT",
                principalColumn: "PROD_CODE",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAREHOUSE_PRODUCT_WH_CODE",
                table: "WAREHOUSE",
                column: "WH_CODE",
                principalTable: "PRODUCT",
                principalColumn: "PROD_CODE",
                onDelete: ReferentialAction.Cascade);
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
                name: "FK_WAREHOUSE_PRODUCT_WH_CODE",
                table: "WAREHOUSE");

            migrationBuilder.AlterColumn<int>(
                name: "WH_CODE",
                table: "WAREHOUSE",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "WH_CODE",
                table: "PRODUCT",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "UNITPRICE",
                table: "PRODUCT",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "STOCK_QTY",
                table: "PRODUCT",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "UNITPRICE",
                table: "ORDER_DETAILS",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "RESERVE_QTY",
                table: "ORDER_DETAILS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "QUANTITY",
                table: "ORDER_DETAILS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PROD_CODE",
                table: "ORDER_DETAILS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ORDER_NO",
                table: "ORDER_DETAILS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "DISCOUNT",
                table: "ORDER_DETAILS",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "DELIVERY_ORDER_QTY",
                table: "ORDER_DETAILS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DELIVERED_QTY",
                table: "ORDER_DETAILS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "COMPLETE_FLG",
                table: "ORDER_DETAILS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "CMP_TAX_RATE",
                table: "ORDER_DETAILS",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HIRE_DATE",
                table: "EMPLOYEE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATE_DATE",
                table: "CUSTOMER",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_WH_CODE",
                table: "PRODUCT",
                column: "WH_CODE");

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
                name: "FK_PRODUCT_WAREHOUSE_WH_CODE",
                table: "PRODUCT",
                column: "WH_CODE",
                principalTable: "WAREHOUSE",
                principalColumn: "WH_CODE");
        }
    }
}
