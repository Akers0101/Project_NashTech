using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<int>(type: "int", nullable: false),
                    IsFirstLogin = table.Column<bool>(type: "bit", nullable: false),
                    StaffCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    AssetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstalledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssetState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.AssetId);
                    table.ForeignKey(
                        name: "FK_Asset_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedToUserId = table.Column<int>(type: "int", nullable: false),
                    AssignedToUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedByUserId = table.Column<int>(type: "int", nullable: false),
                    AssignedByUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignmentState = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignment_Asset_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Asset",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignment_User_AssignedByUserId",
                        column: x => x.AssignedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignment_User_AssignedToUserId",
                        column: x => x.AssignedToUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName", "Prefix" },
                values: new object[,]
                {
                    { 1, "Laptop", "LA" },
                    { 2, "Monitor", "MO" },
                    { 3, "Personal Computer", "PC" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "DateOfBirth", "FirstName", "Gender", "IsFirstLogin", "JoinedDate", "LastName", "Location", "PasswordHash", "Role", "StaffCode", "UserName", "UserState" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dao", 0, true, new DateTime(2022, 8, 4, 15, 51, 48, 454, DateTimeKind.Local).AddTicks(7071), "Quy Vuong", 0, "$2a$11$rS2i8frKNAk3x2kwtlLgv.dPhJgVDJMPc1G3JdG4C9ZGZ5VK7Vxba", 0, "AD1", "Admin", 1 },
                    { 2, new DateTime(1999, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bui", 0, true, new DateTime(2022, 8, 4, 15, 51, 48, 637, DateTimeKind.Local).AddTicks(1556), "Chi Huong", 0, "$2a$11$qo21cybs8i6hRkjAB1RFJ.PDG4xQAtAJidhsgTjwnP45X0YHOSDJS", 1, "US2", "Staff", 1 },
                    { 3, new DateTime(2001, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bui", 1, true, new DateTime(2022, 8, 4, 15, 51, 48, 818, DateTimeKind.Local).AddTicks(624), "Chi Huong", 1, "$2a$11$2H2REEseJTHYk/6OSmEEX.qlPq1lxExbCf7Impi3PUI8Wlfiri2kC", 1, "........", "Huong", 0 }
                });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "AssetId", "AssetCode", "AssetName", "AssetState", "CategoryId", "CategoryName", "InstalledDate", "Location", "Specification" },
                values: new object[] { 1, "LA1", "HP Zenbook8", 0, 1, "Laptop", new DateTime(2022, 8, 4, 15, 51, 48, 258, DateTimeKind.Local).AddTicks(3349), "sample location", "this is sample data" });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "AssetId", "AssetCode", "AssetName", "AssetState", "CategoryId", "CategoryName", "InstalledDate", "Location", "Specification" },
                values: new object[] { 2, "MO1", "Dell UltralSharp", 0, 2, "Monitor", new DateTime(2022, 8, 4, 15, 51, 48, 258, DateTimeKind.Local).AddTicks(3370), "sample location", "this is sample data" });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "AssetId", "AssetCode", "AssetName", "AssetState", "CategoryId", "CategoryName", "InstalledDate", "Location", "Specification" },
                values: new object[] { 3, "PC1", "HP PC", 0, 3, "Personal Computer", new DateTime(2022, 8, 4, 15, 51, 48, 258, DateTimeKind.Local).AddTicks(3372), "sample location", "this is sample data" });

            migrationBuilder.InsertData(
                table: "Assignment",
                columns: new[] { "AssignmentId", "AssetCode", "AssetId", "AssetName", "AssignedByUserId", "AssignedByUserName", "AssignedDate", "AssignedToUserId", "AssignedToUserName", "AssignmentState", "Location", "Note", "Specification" },
                values: new object[] { 2, "MO000002", 1, "Changed", 1, "Admin", new DateTime(2022, 8, 4, 15, 51, 48, 818, DateTimeKind.Local).AddTicks(1067), 2, "Staff", 0, "Hanoi", "seeding data", "" });

            migrationBuilder.InsertData(
                table: "Assignment",
                columns: new[] { "AssignmentId", "AssetCode", "AssetId", "AssetName", "AssignedByUserId", "AssignedByUserName", "AssignedDate", "AssignedToUserId", "AssignedToUserName", "AssignmentState", "Location", "Note", "Specification" },
                values: new object[] { 3, "PC000007", 2, "Dell Vostro3578", 1, "Admin", new DateTime(2022, 8, 4, 15, 51, 48, 818, DateTimeKind.Local).AddTicks(1079), 2, "Staff", 0, "Hanoi", "seeding data", "" });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_CategoryId",
                table: "Asset",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_AssetId",
                table: "Assignment",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_AssignedByUserId",
                table: "Assignment",
                column: "AssignedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_AssignedToUserId",
                table: "Assignment",
                column: "AssignedToUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
