using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class Alter_Userdbo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserState",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 1,
                columns: new[] { "AssetState", "InstalledDate" },
                values: new object[] { 1, new DateTime(2022, 4, 13, 11, 47, 28, 875, DateTimeKind.Local).AddTicks(5682) });

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 2,
                columns: new[] { "AssetState", "InstalledDate" },
                values: new object[] { 1, new DateTime(2022, 4, 13, 11, 47, 28, 875, DateTimeKind.Local).AddTicks(5709) });

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 3,
                columns: new[] { "AssetState", "InstalledDate" },
                values: new object[] { 1, new DateTime(2022, 4, 13, 11, 47, 28, 875, DateTimeKind.Local).AddTicks(5711) });

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "AssignmentId",
                keyValue: 1,
                column: "AssignedDate",
                value: new DateTime(2022, 4, 13, 11, 47, 29, 465, DateTimeKind.Local).AddTicks(2864));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "JoindedDate", "PasswordHash", "UserState" },
                values: new object[] { new DateTime(2022, 4, 13, 11, 47, 29, 71, DateTimeKind.Local).AddTicks(671), "$2a$11$dSyLKvypV2m5IOLbdAjlH.17aRuS/xwo3U6U6Jb8khjkQZl.b3saW", 1 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "JoindedDate", "PasswordHash", "UserState" },
                values: new object[] { new DateTime(2022, 4, 13, 11, 47, 29, 265, DateTimeKind.Local).AddTicks(7631), "$2a$11$DBqOwAKfk1XX2MOX4KOrLegy8Df352WnL8JQcHqw4Dy9RGFoOQGLS", 1 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "Gender", "JoindedDate", "PasswordHash" },
                values: new object[] { 1, new DateTime(2022, 4, 13, 11, 47, 29, 465, DateTimeKind.Local).AddTicks(2363), "$2a$11$unDoa6l5.WNHAV.gxHw5JeNiISE4IQYqxg8Wdn0y0etTwk.uN4X12" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserState",
                table: "User");

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 1,
                columns: new[] { "AssetState", "InstalledDate" },
                values: new object[] { 0, new DateTime(2022, 4, 10, 22, 59, 9, 551, DateTimeKind.Local).AddTicks(8102) });

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 2,
                columns: new[] { "AssetState", "InstalledDate" },
                values: new object[] { 0, new DateTime(2022, 4, 10, 22, 59, 9, 551, DateTimeKind.Local).AddTicks(8121) });

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 3,
                columns: new[] { "AssetState", "InstalledDate" },
                values: new object[] { 0, new DateTime(2022, 4, 10, 22, 59, 9, 551, DateTimeKind.Local).AddTicks(8123) });

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "AssignmentId",
                keyValue: 1,
                column: "AssignedDate",
                value: new DateTime(2022, 4, 10, 22, 59, 10, 122, DateTimeKind.Local).AddTicks(1387));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "JoindedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 10, 22, 59, 9, 741, DateTimeKind.Local).AddTicks(354), "$2a$11$YNh9RY2s6cMOhcueX9VCLuZ785yNUgeAuNO/vs/mfIShqVc0wqI.C" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "JoindedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 10, 22, 59, 9, 930, DateTimeKind.Local).AddTicks(6486), "$2a$11$BjWub3Z0fDdiFcv38WF/juzaKtaEgjZzQ2gYY.UDVuvhr2N3NsAnu" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "Gender", "JoindedDate", "PasswordHash" },
                values: new object[] { 2, new DateTime(2022, 4, 10, 22, 59, 10, 122, DateTimeKind.Local).AddTicks(925), "$2a$11$oxmftfK2qziha.sqwo6og.CPW5L.v8ffp/ow.33EeKtIocMD6zuPy" });
        }
    }
}
