﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Data;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220420035409_Alter_Assignment.dbo5")]
    partial class Alter_Assignmentdbo5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("backend.Entities.Asset", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssetId"), 1L, 1);

                    b.Property<string>("AssetCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AssetState")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InstalledDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssetId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Asset", (string)null);

                    b.HasData(
                        new
                        {
                            AssetId = 1,
                            AssetCode = "LA1",
                            AssetName = "HP Zenbook8",
                            AssetState = 0,
                            CategoryId = 1,
                            CategoryName = "Laptop",
                            InstalledDate = new DateTime(2022, 4, 20, 10, 54, 8, 724, DateTimeKind.Local).AddTicks(9838),
                            Location = "sample location",
                            Specification = "this is sample data"
                        },
                        new
                        {
                            AssetId = 2,
                            AssetCode = "MO1",
                            AssetName = "Dell UltralSharp",
                            AssetState = 0,
                            CategoryId = 2,
                            CategoryName = "Monitor",
                            InstalledDate = new DateTime(2022, 4, 20, 10, 54, 8, 724, DateTimeKind.Local).AddTicks(9852),
                            Location = "sample location",
                            Specification = "this is sample data"
                        },
                        new
                        {
                            AssetId = 3,
                            AssetCode = "PC1",
                            AssetName = "HP PC",
                            AssetState = 0,
                            CategoryId = 3,
                            CategoryName = "Personal Computer",
                            InstalledDate = new DateTime(2022, 4, 20, 10, 54, 8, 724, DateTimeKind.Local).AddTicks(9854),
                            Location = "sample location",
                            Specification = "this is sample data"
                        });
                });

            modelBuilder.Entity("backend.Entities.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentId"), 1L, 1);

                    b.Property<string>("AssetCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AssetId")
                        .HasColumnType("int");

                    b.Property<string>("AssetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AssignedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("AssignedByUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AssignedToUserId")
                        .HasColumnType("int");

                    b.Property<string>("AssignedToUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AssignmentState")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssignmentId");

                    b.HasIndex("AssetId");

                    b.HasIndex("AssignedByUserId");

                    b.HasIndex("AssignedToUserId");

                    b.ToTable("Assignment", (string)null);

                    b.HasData(
                        new
                        {
                            AssignmentId = 2,
                            AssetCode = "MO000002",
                            AssetId = 40,
                            AssetName = "Changed",
                            AssignedByUserId = 1,
                            AssignedByUserName = "Admin",
                            AssignedDate = new DateTime(2022, 4, 20, 10, 54, 9, 312, DateTimeKind.Local).AddTicks(4230),
                            AssignedToUserId = 2,
                            AssignedToUserName = "Staff",
                            AssignmentState = 0,
                            Location = "Hanoi",
                            Note = "seeding data",
                            Specification = ""
                        },
                        new
                        {
                            AssignmentId = 3,
                            AssetCode = "PC000007",
                            AssetId = 44,
                            AssetName = "Dell Vostro3578",
                            AssignedByUserId = 1,
                            AssignedByUserName = "Admin",
                            AssignedDate = new DateTime(2022, 4, 20, 10, 54, 9, 312, DateTimeKind.Local).AddTicks(4249),
                            AssignedToUserId = 2,
                            AssignedToUserName = "Staff",
                            AssignmentState = 0,
                            Location = "Hanoi",
                            Note = "seeding data",
                            Specification = ""
                        });
                });

            modelBuilder.Entity("backend.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Laptop",
                            Prefix = "LA"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Monitor",
                            Prefix = "MO"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Personal Computer",
                            Prefix = "PC"
                        });
                });

            modelBuilder.Entity("backend.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsFirstLogin")
                        .HasColumnType("bit");

                    b.Property<DateTime>("JoinedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Location")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("StaffCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("UserState")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            DateOfBirth = new DateTime(2000, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Dao",
                            Gender = 0,
                            IsFirstLogin = true,
                            JoinedDate = new DateTime(2022, 4, 20, 10, 54, 8, 922, DateTimeKind.Local).AddTicks(9287),
                            LastName = "Quy Vuong",
                            Location = 0,
                            PasswordHash = "$2a$11$4Rpe6Vz/3aIvJJY10P0LiOlUvlA1jO5.d9puDodZbK1ENewDbIgRS",
                            Role = 0,
                            StaffCode = "AD1",
                            UserName = "Admin",
                            UserState = 1
                        },
                        new
                        {
                            UserId = 2,
                            DateOfBirth = new DateTime(1999, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Bui",
                            Gender = 0,
                            IsFirstLogin = true,
                            JoinedDate = new DateTime(2022, 4, 20, 10, 54, 9, 117, DateTimeKind.Local).AddTicks(8201),
                            LastName = "Chi Huong",
                            Location = 0,
                            PasswordHash = "$2a$11$iLtV8uiKmZHuo9VoNTYKKuTPhOLwt4py4obRGe8DwE1txixVDPh2W",
                            Role = 1,
                            StaffCode = "US2",
                            UserName = "Staff",
                            UserState = 1
                        },
                        new
                        {
                            UserId = 3,
                            DateOfBirth = new DateTime(2001, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Bui",
                            Gender = 1,
                            IsFirstLogin = true,
                            JoinedDate = new DateTime(2022, 4, 20, 10, 54, 9, 312, DateTimeKind.Local).AddTicks(3735),
                            LastName = "Chi Huong",
                            Location = 1,
                            PasswordHash = "$2a$11$4bG7esMGAsCDwMpYyX26aOOa7qL4Vc/KgNqrEVX2l9D6tOUPMs2le",
                            Role = 1,
                            StaffCode = "........",
                            UserName = "Huong",
                            UserState = 0
                        });
                });

            modelBuilder.Entity("backend.Entities.Asset", b =>
                {
                    b.HasOne("backend.Entities.Category", "Category")
                        .WithMany("Assets")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("backend.Entities.Assignment", b =>
                {
                    b.HasOne("backend.Entities.Asset", "Asset")
                        .WithMany("Assignments")
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("backend.Entities.User", "AssignedBy")
                        .WithMany("AssignedBy")
                        .HasForeignKey("AssignedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("backend.Entities.User", "AssignedTo")
                        .WithMany("AssignedTo")
                        .HasForeignKey("AssignedToUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("AssignedBy");

                    b.Navigation("AssignedTo");
                });

            modelBuilder.Entity("backend.Entities.Asset", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("backend.Entities.Category", b =>
                {
                    b.Navigation("Assets");
                });

            modelBuilder.Entity("backend.Entities.User", b =>
                {
                    b.Navigation("AssignedBy");

                    b.Navigation("AssignedTo");
                });
#pragma warning restore 612, 618
        }
    }
}
