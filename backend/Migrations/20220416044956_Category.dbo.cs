using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class Categorydbo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Perfix",
                table: "Category",
                newName: "Prefix");

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 1,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 16, 11, 49, 55, 126, DateTimeKind.Local).AddTicks(1645));

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 2,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 16, 11, 49, 55, 126, DateTimeKind.Local).AddTicks(1665));

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 3,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 16, 11, 49, 55, 126, DateTimeKind.Local).AddTicks(1667));

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "AssignmentId",
                keyValue: 2,
                column: "AssignedDate",
                value: new DateTime(2022, 4, 16, 11, 49, 55, 730, DateTimeKind.Local).AddTicks(1179));

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "AssignmentId",
                keyValue: 3,
                column: "AssignedDate",
                value: new DateTime(2022, 4, 16, 11, 49, 55, 730, DateTimeKind.Local).AddTicks(1198));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "JoinedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 16, 11, 49, 55, 319, DateTimeKind.Local).AddTicks(4596), "$2a$11$dOYGAOIvOigP1QDHmx0rlOG7QYSSFuesWAwyAAvv8FqyWVldUkM12" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "JoinedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 16, 11, 49, 55, 529, DateTimeKind.Local).AddTicks(1393), "$2a$11$bCkTQ5/Kp2Azg/pbRLAoTO40f716MKNorK4ri26Ub97aQGHSQ/3EC" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "JoinedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 16, 11, 49, 55, 730, DateTimeKind.Local).AddTicks(728), "$2a$11$qtiXwruPCkS9UlDWjNiCxOvVMkt5cHhjn8YvwNOqSnUpGHOMjG5b." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prefix",
                table: "Category",
                newName: "Perfix");

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

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "AssignmentId",
                keyValue: 2,
                column: "AssignedDate",
                value: new DateTime(2022, 4, 15, 14, 57, 38, 496, DateTimeKind.Local).AddTicks(4323));

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "AssignmentId",
                keyValue: 3,
                column: "AssignedDate",
                value: new DateTime(2022, 4, 15, 14, 57, 38, 496, DateTimeKind.Local).AddTicks(4339));

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
    }
}
