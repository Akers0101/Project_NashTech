using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class Alter_Assignmentdbo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assignment",
                keyColumn: "AssignmentId",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "AssetCode",
                table: "Assignment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AssetName",
                table: "Assignment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AssignedByUserName",
                table: "Assignment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AssignedToUserName",
                table: "Assignment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Assignment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 1,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 15, 14, 15, 6, 143, DateTimeKind.Local).AddTicks(6755));

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 2,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 15, 14, 15, 6, 143, DateTimeKind.Local).AddTicks(6773));

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 3,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 15, 14, 15, 6, 143, DateTimeKind.Local).AddTicks(6775));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "JoinedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 15, 14, 15, 6, 335, DateTimeKind.Local).AddTicks(9867), "$2a$11$4pgGVVWJTkIlN/xfisqeRuHiV4/JYt.aNb278v9TZpg2mB49E1saW" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "JoinedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 15, 14, 15, 6, 539, DateTimeKind.Local).AddTicks(7730), "$2a$11$5EHf2eOtDCguUNd6gpDB6.nVf.5yNN0/ZfV2Dq6jZGqG3ZFuzXeUW" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "JoinedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 15, 14, 15, 6, 735, DateTimeKind.Local).AddTicks(8320), "$2a$11$M6ix7m/rzUWTXwxvBRq9.eMVL2iWoZZN4KfEm4drv/Azbhdm902Fm" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssetCode",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "AssetName",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "AssignedByUserName",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "AssignedToUserName",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Assignment");

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 1,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 13, 21, 12, 48, 784, DateTimeKind.Local).AddTicks(9398));

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 2,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 13, 21, 12, 48, 784, DateTimeKind.Local).AddTicks(9420));

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 3,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 13, 21, 12, 48, 784, DateTimeKind.Local).AddTicks(9422));

            migrationBuilder.InsertData(
                table: "Assignment",
                columns: new[] { "AssignmentId", "AssetId", "AssignedByUserId", "AssignedDate", "AssignedToUserId", "AssignmentState", "Note" },
                values: new object[] { 1, 2, 1, new DateTime(2022, 4, 13, 21, 12, 49, 375, DateTimeKind.Local).AddTicks(2123), 2, 0, "this is sample data" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "JoinedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 13, 21, 12, 48, 984, DateTimeKind.Local).AddTicks(1787), "$2a$11$CuZtFKAfyQBkgB8HT1Las.gmVm8GzRojKQzRJP5ZQAiRKOEKDGn56" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "JoinedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 13, 21, 12, 49, 179, DateTimeKind.Local).AddTicks(7855), "$2a$11$YgSAmFODK4V4w12AX9eCXOn/cdWZlELlasjmBK7dH7V1514mrYXr." });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "JoinedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 13, 21, 12, 49, 375, DateTimeKind.Local).AddTicks(1657), "$2a$11$XHYu.JhFU7Co5MFVtrL1.eeVsO3styY/nnUb3KWlSHK0gloQccATu" });
        }
    }
}
