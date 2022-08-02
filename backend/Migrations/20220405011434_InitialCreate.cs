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
                    Perfix = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFirstLogin = table.Column<bool>(type: "bit", nullable: false),
                    StaffCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    JoindedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    AssignedByUserId = table.Column<int>(type: "int", nullable: false),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignment_Asset_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Asset",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "ReturningRequest",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestedByUserId = table.Column<int>(type: "int", nullable: false),
                    ProcessedByUserId = table.Column<int>(type: "int", nullable: false),
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    RequestState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturningRequest", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_ReturningRequest_Assignment_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignment",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReturningRequest_User_ProcessedByUserId",
                        column: x => x.ProcessedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReturningRequest_User_RequestedByUserId",
                        column: x => x.RequestedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName", "Perfix" },
                values: new object[,]
                {
                    { 1, "Laptop", "LA" },
                    { 2, "Monitor", "MO" },
                    { 3, "Personal Computer", "PC" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "DateOfBirth", "FirstName", "Gender", "IsFirstLogin", "JoindedDate", "LastName", "Location", "PasswordHash", "Role", "StaffCode", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dao", 0, true, new DateTime(2022, 4, 5, 8, 14, 33, 700, DateTimeKind.Local).AddTicks(4116), "Quy Vuong", "Ha Noi", "$2a$11$TcTBPgRfsxbOnLlMSpBIvufb1LU9fn31NiHEC6cJe6jp77xYoleay", 0, "AD1", "Admin" },
                    { 2, new DateTime(1999, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bui", 0, true, new DateTime(2022, 4, 5, 8, 14, 33, 870, DateTimeKind.Local).AddTicks(6839), "Chi Huong", "Bac Giang", "$2a$11$5sGofnayV8S.haZ69VMwKexwA7wcbOFZ9JaSrN1QcYTD1UzoDy2Ra", 1, "US2", "Staff" },
                    { 3, new DateTime(2001, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bui", 2, true, new DateTime(2022, 4, 5, 8, 14, 34, 54, DateTimeKind.Local).AddTicks(3791), "Chi Huong", "Cao Bang", "$2a$11$Vh8sdbkegu4PoNLWtOZmDeJ7MlPKP1oNcqIY14JkG7fkClAYV6LMS", 1, "........", "Huong" }
                });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "AssetId", "AssetCode", "AssetName", "AssetState", "CategoryId", "CategoryName", "InstalledDate", "Location", "Specification" },
                values: new object[] { 1, "LA1", "HP Zenbook8", 0, 1, "Laptop", new DateTime(2022, 4, 5, 8, 14, 33, 529, DateTimeKind.Local).AddTicks(810), "sample location", "this is sample data" });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "AssetId", "AssetCode", "AssetName", "AssetState", "CategoryId", "CategoryName", "InstalledDate", "Location", "Specification" },
                values: new object[] { 2, "MO1", "Dell UltralSharp", 0, 2, "Monitor", new DateTime(2022, 4, 5, 8, 14, 33, 529, DateTimeKind.Local).AddTicks(825), "sample location", "this is sample data" });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "AssetId", "AssetCode", "AssetName", "AssetState", "CategoryId", "CategoryName", "InstalledDate", "Location", "Specification" },
                values: new object[] { 3, "PC1", "HP PC", 0, 3, "Personal Computer", new DateTime(2022, 4, 5, 8, 14, 33, 529, DateTimeKind.Local).AddTicks(826), "sample location", "this is sample data" });

            migrationBuilder.InsertData(
                table: "Assignment",
                columns: new[] { "AssignmentId", "AssetId", "AssignedByUserId", "AssignedDate", "AssignedToUserId", "Note" },
                values: new object[] { 1, 2, 1, new DateTime(2022, 4, 5, 8, 14, 34, 54, DateTimeKind.Local).AddTicks(4206), 2, "this is sample data" });

            migrationBuilder.InsertData(
                table: "ReturningRequest",
                columns: new[] { "RequestId", "AssignmentId", "ProcessedByUserId", "RequestState", "RequestedByUserId" },
                values: new object[] { 1, 1, 1, 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_CategoryId",
                table: "Asset",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_AssetId",
                table: "Assignment",
                column: "AssetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_AssignedByUserId",
                table: "Assignment",
                column: "AssignedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_AssignedToUserId",
                table: "Assignment",
                column: "AssignedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturningRequest_AssignmentId",
                table: "ReturningRequest",
                column: "AssignmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReturningRequest_ProcessedByUserId",
                table: "ReturningRequest",
                column: "ProcessedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturningRequest_RequestedByUserId",
                table: "ReturningRequest",
                column: "RequestedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReturningRequest");

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
