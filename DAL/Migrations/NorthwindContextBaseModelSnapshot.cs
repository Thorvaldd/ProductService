using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using DAL.Models;

namespace Dal.Migrations
{
    [DbContext(typeof(NorthwindContextBase))]
    partial class NorthwindContextBaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Models.AddressDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Region");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DAL.Models.Categories", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<byte[]>("Picture");

                    b.HasKey("CategoryID");
                });

            modelBuilder.Entity("DAL.Models.Customers", b =>
                {
                    b.Property<string>("CustomerID");

                    b.Property<int?>("AddressDetailsId");

                    b.Property<string>("CompanyName")
                        .IsRequired();

                    b.Property<string>("ContactName");

                    b.Property<string>("ContactTitle");

                    b.Property<string>("Fax");

                    b.Property<string>("Phone");

                    b.HasKey("CustomerID");
                });

            modelBuilder.Entity("DAL.Models.OrderDetails", b =>
                {
                    b.Property<int>("OrderID");

                    b.Property<int>("ProductID");

                    b.Property<float>("Discount");

                    b.Property<short>("Quantity");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("OrderID", "ProductID");

                    b.HasAnnotation("Relational:TableName", "Order Details");
                });

            modelBuilder.Entity("DAL.Models.Orders", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerID");

                    b.Property<int>("EmployeeID");

                    b.Property<decimal?>("Freight");

                    b.Property<DateTime?>("OrderDate");

                    b.Property<DateTime?>("RequiredDate");

                    b.Property<string>("ShipAddress");

                    b.Property<string>("ShipCity");

                    b.Property<string>("ShipCountry");

                    b.Property<string>("ShipName");

                    b.Property<string>("ShipPostalCode");

                    b.Property<string>("ShipRegion");

                    b.Property<int>("ShipVia");

                    b.Property<DateTime?>("ShippedDate");

                    b.HasKey("OrderID");
                });

            modelBuilder.Entity("DAL.Models.Products", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryID");

                    b.Property<bool>("Discontinued");

                    b.Property<string>("ProductName")
                        .IsRequired();

                    b.Property<string>("QuantityPerUnit");

                    b.Property<short>("ReorderLevel");

                    b.Property<int>("SupplierID");

                    b.Property<decimal?>("UnitPrice");

                    b.Property<short>("UnitsInStock");

                    b.Property<short>("UnitsOnOrder");

                    b.HasKey("ProductID");
                });

            modelBuilder.Entity("DAL.Models.Customers", b =>
                {
                    b.HasOne("DAL.Models.AddressDetails")
                        .WithMany()
                        .HasForeignKey("AddressDetailsId");
                });

            modelBuilder.Entity("DAL.Models.OrderDetails", b =>
                {
                    b.HasOne("DAL.Models.Orders")
                        .WithMany()
                        .HasForeignKey("OrderID");

                    b.HasOne("DAL.Models.Products")
                        .WithMany()
                        .HasForeignKey("ProductID");
                });

            modelBuilder.Entity("DAL.Models.Orders", b =>
                {
                    b.HasOne("DAL.Models.Customers")
                        .WithMany()
                        .HasForeignKey("CustomerID");
                });

            modelBuilder.Entity("DAL.Models.Products", b =>
                {
                    b.HasOne("DAL.Models.Categories")
                        .WithMany()
                        .HasForeignKey("CategoryID");
                });
        }
    }
}
