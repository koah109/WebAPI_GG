﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLBH.Data;

#nullable disable

namespace QLBH.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QLBH.Models.Customer", b =>
                {
                    b.Property<int>("CUST_CODE")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "cust_code");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CUST_CODE"));

                    b.Property<string>("ADDRESS")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "address");

                    b.Property<string>("CUST_NAME")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "cust_name");

                    b.Property<string>("EMAIL")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "email");

                    b.Property<string>("PHONE")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "phone");

                    b.Property<string>("UPDATER")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "updater");

                    b.Property<DateTime?>("UPDATE_DATE")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "update_date");

                    b.HasKey("CUST_CODE");

                    b.ToTable("CUSTOMER");
                });

            modelBuilder.Entity("QLBH.Models.Employee", b =>
                {
                    b.Property<int>("EMP_CODE")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EMP_CODE"));

                    b.Property<string>("EMP_NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("HIRE_DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("POSITION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UPDATER")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EMP_CODE");

                    b.ToTable("EMPLOYEE");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Department", b =>
                {
                    b.Property<int>("DEPT_CODE")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DEPT_CODE"));

                    b.Property<string>("ADDRESS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DEPT_NAME")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DEPT_CODE");

                    b.ToTable("DEPARTMENT");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Warehouse", b =>
                {
                    b.Property<int>("WH_CODE")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WH_CODE"));

                    b.Property<string>("LOCATION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WH_NAME")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WH_CODE");

                    b.ToTable("WAREHOUSE");
                });

            modelBuilder.Entity("QLBH.Models.ORDER_DETAILS", b =>
                {
                    b.Property<int>("SO_ROW_NO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SO_ROW_NO"));

                    b.Property<float>("CMP_TAX_RATE")
                        .HasColumnType("real");

                    b.Property<int>("COMPLETE_FLG")
                        .HasColumnType("int");

                    b.Property<int>("DELIVERED_QTY")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DELIVERY_DATE")
                        .HasColumnType("datetime2");

                    b.Property<int>("DELIVERY_ORDER_QTY")
                        .HasColumnType("int");

                    b.Property<float>("DISCOUNT")
                        .HasColumnType("real");

                    b.Property<int>("ORDER_NO")
                        .HasColumnType("int");

                    b.Property<int>("PROD_CODE")
                        .HasColumnType("int");

                    b.Property<string>("PROD_NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QUANTITY")
                        .HasColumnType("int");

                    b.Property<int>("RESERVE_QTY")
                        .HasColumnType("int");

                    b.Property<float>("UNITPRICE")
                        .HasColumnType("real");

                    b.Property<string>("UPDATER")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UPDATE_DATE")
                        .HasColumnType("datetime2");

                    b.HasKey("SO_ROW_NO");

                    b.HasIndex("ORDER_NO");

                    b.HasIndex("PROD_CODE");

                    b.ToTable("ORDER_DETAILS");
                });

            modelBuilder.Entity("QLBH.Models.Orders", b =>
                {
                    b.Property<int>("ORDER_NO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ORDER_NO"));

                    b.Property<int>("CMP_TAX")
                        .HasColumnType("int");

                    b.Property<int>("CUSTORDER_NO")
                        .HasColumnType("int");

                    b.Property<int>("CUST_CODE")
                        .HasColumnType("int");

                    b.Property<int>("CUST_SUB_NO")
                        .HasColumnType("int");

                    b.Property<int>("DEPT_CODE")
                        .HasColumnType("int");

                    b.Property<int>("EMP_CODE")
                        .HasColumnType("int");

                    b.Property<DateTime>("ORDER_DATE")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("REQUIRED_DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("SLIP_COMMENT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UPDATER")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UPDATE_DATE")
                        .HasColumnType("datetime2");

                    b.Property<int>("WH_CODE")
                        .HasColumnType("int");

                    b.HasKey("ORDER_NO");

                    b.HasIndex("CUST_CODE");

                    b.HasIndex("DEPT_CODE");

                    b.HasIndex("EMP_CODE");

                    b.HasIndex("WH_CODE");

                    b.ToTable("ORDERS");
                });

            modelBuilder.Entity("QLBH.Models.Product", b =>
                {
                    b.Property<int>("PROD_CODE")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PROD_CODE"));

                    b.Property<string>("PROD_NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("STOCK_QTY")
                        .HasColumnType("int");

                    b.Property<float>("UNITPRICE")
                        .HasColumnType("real");

                    b.Property<string>("UPDATER")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UPDATE_DATE")
                        .HasColumnType("datetime2");

                    b.Property<int>("WH_CODE")
                        .HasColumnType("int");

                    b.HasKey("PROD_CODE");

                    b.HasIndex("WH_CODE");

                    b.ToTable("PRODUCT");
                });

            modelBuilder.Entity("QLBH.Models.ORDER_DETAILS", b =>
                {
                    b.HasOne("QLBH.Models.Orders", "Orders")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ORDER_NO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLBH.Models.Product", "Product")
                        .WithMany("Orderdetails")
                        .HasForeignKey("PROD_CODE")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("QLBH.Models.Orders", b =>
                {
                    b.HasOne("QLBH.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CUST_CODE")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLBH.Models.Entities.Department", "Department")
                        .WithMany("Orders")
                        .HasForeignKey("DEPT_CODE")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLBH.Models.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EMP_CODE")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLBH.Models.Entities.Warehouse", "Warehouse")
                        .WithMany("Orders")
                        .HasForeignKey("WH_CODE")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Department");

                    b.Navigation("Employee");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("QLBH.Models.Product", b =>
                {
                    b.HasOne("QLBH.Models.Entities.Warehouse", "Warehouse")
                        .WithMany("Product")
                        .HasForeignKey("WH_CODE")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("QLBH.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("QLBH.Models.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Department", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Warehouse", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("QLBH.Models.Orders", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("QLBH.Models.Product", b =>
                {
                    b.Navigation("Orderdetails");
                });
#pragma warning restore 612, 618
        }
    }
}
