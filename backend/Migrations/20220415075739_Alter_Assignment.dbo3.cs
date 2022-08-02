using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class Alter_Assignmentdbo3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 1,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 15, 14, 57, 37, 917, DateTimeKind.Local).AddTicks(3866));

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 2,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 15, 14, 57, 37, 917, DateTimeKind.Local).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 3,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 15, 14, 57, 37, 917, DateTimeKind.Local).AddTicks(3906));

            migrationBuilder.InsertData(
                table: "Assignment",
                columns: new[] { "AssignmentId", "AssetCode", "AssetId", "AssetName", "AssignedByUserId", "AssignedByUserName", "AssignedDate", "AssignedToUserId", "AssignedToUserName", "AssignmentState", "Location", "Note" },
                values: new object[,]
                {
                    { 2, "MO000002", 40, "Changed", 1, "Admin", new DateTime(2022, 4, 15, 14, 57, 38, 496, DateTimeKind.Local).AddTicks(4323), 2, "Staff", 0, "Hanoi", "seeding data" },
                    { 3, "PC000007", 44, "Dell Vostro3578", 1, "Admin", new DateTime(2022, 4, 15, 14, 57, 38, 496, DateTimeKind.Local).AddTicks(4339), 2, "Staff", 0, "Hanoi", "seeding data" }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "JoinedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 15, 14, 57, 38, 109, DateTimeKind.Local).AddTicks(6146), "$2a$11$oG2m9fNwRo49vnWsYsS2KuJ85H30NZ9yptFhvxDpYstSoW1uQjl9O" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "JoinedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 15, 14, 57, 38, 303, DateTimeKind.Local).AddTicks(466), "$2a$11$juptf./fKnXqjtRIiwzETOjLzSvMAOazFB2vbW9l7vOO/yi5z28am" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "JoinedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 15, 14, 57, 38, 496, DateTimeKind.Local).AddTicks(3877), "$2a$11$GunsQ9q66xGq6jpcWWaLU.XYi0nefyZZuiF2FazVKJebtXDW2FKv." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assignment",
                keyColumn: "AssignmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assignment",
                keyColumn: "AssignmentId",
                keyValue: 3);

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
    }
}
