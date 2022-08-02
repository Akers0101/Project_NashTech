using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class Alter_Assignmentdbo4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReturningRequest",
                keyColumn: "RequestId",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "Specification",
                table: "Assignment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 1,
                columns: new[] { "AssetState", "InstalledDate" },
                values: new object[] { 0, new DateTime(2022, 4, 17, 15, 53, 22, 691, DateTimeKind.Local).AddTicks(5446) });

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 2,
                columns: new[] { "AssetState", "InstalledDate" },
                values: new object[] { 0, new DateTime(2022, 4, 17, 15, 53, 22, 691, DateTimeKind.Local).AddTicks(5465) });

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 3,
                columns: new[] { "AssetState", "InstalledDate" },
                values: new object[] { 0, new DateTime(2022, 4, 17, 15, 53, 22, 691, DateTimeKind.Local).AddTicks(5467) });

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "AssignmentId",
                keyValue: 2,
                columns: new[] { "AssignedDate", "Specification" },
                values: new object[] { new DateTime(2022, 4, 17, 15, 53, 23, 275, DateTimeKind.Local).AddTicks(29), "" });

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "AssignmentId",
                keyValue: 3,
                columns: new[] { "AssignedDate", "Specification" },
                values: new object[] { new DateTime(2022, 4, 17, 15, 53, 23, 275, DateTimeKind.Local).AddTicks(46), "" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "JoinedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 17, 15, 53, 22, 885, DateTimeKind.Local).AddTicks(6228), "$2a$11$LM4JdYDi7p6pnvD8zblfPeNG5Dhsou4h5vfoST1iltjwuQ2gCs6Kq" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "JoinedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 17, 15, 53, 23, 77, DateTimeKind.Local).AddTicks(2785), "$2a$11$JE1VoMHokdbVnVWJCOUV0e3GV.hXT/sVz4hsjG4LCmO/UVHZobk2e" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "JoinedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 17, 15, 53, 23, 274, DateTimeKind.Local).AddTicks(9486), "$2a$11$k0dRV3Ci48T/.hhT3JurXeDOO50DwFJBjFSvy9OPrzzL9yH3miXZK" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specification",
                table: "Assignment");

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 1,
                columns: new[] { "AssetState", "InstalledDate" },
                values: new object[] { 1, new DateTime(2022, 4, 16, 11, 49, 55, 126, DateTimeKind.Local).AddTicks(1645) });

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 2,
                columns: new[] { "AssetState", "InstalledDate" },
                values: new object[] { 1, new DateTime(2022, 4, 16, 11, 49, 55, 126, DateTimeKind.Local).AddTicks(1665) });

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 3,
                columns: new[] { "AssetState", "InstalledDate" },
                values: new object[] { 1, new DateTime(2022, 4, 16, 11, 49, 55, 126, DateTimeKind.Local).AddTicks(1667) });

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

            migrationBuilder.InsertData(
                table: "ReturningRequest",
                columns: new[] { "RequestId", "AssignmentId", "ProcessedByUserId", "RequestState", "RequestedByUserId" },
                values: new object[] { 1, 1, 1, 1, 2 });

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
    }
}
