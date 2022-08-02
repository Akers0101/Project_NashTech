using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class Alter_Assignmentdbo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignmentState",
                table: "Assignment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 1,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 10, 22, 59, 9, 551, DateTimeKind.Local).AddTicks(8102));

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 2,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 10, 22, 59, 9, 551, DateTimeKind.Local).AddTicks(8121));

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 3,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 10, 22, 59, 9, 551, DateTimeKind.Local).AddTicks(8123));

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
                columns: new[] { "JoindedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 10, 22, 59, 10, 122, DateTimeKind.Local).AddTicks(925), "$2a$11$oxmftfK2qziha.sqwo6og.CPW5L.v8ffp/ow.33EeKtIocMD6zuPy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignmentState",
                table: "Assignment");

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 1,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 10, 15, 57, 44, 538, DateTimeKind.Local).AddTicks(3962));

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 2,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 10, 15, 57, 44, 538, DateTimeKind.Local).AddTicks(4034));

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 3,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 10, 15, 57, 44, 538, DateTimeKind.Local).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "AssignmentId",
                keyValue: 1,
                column: "AssignedDate",
                value: new DateTime(2022, 4, 10, 15, 57, 45, 106, DateTimeKind.Local).AddTicks(1103));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "JoindedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 10, 15, 57, 44, 728, DateTimeKind.Local).AddTicks(3811), "$2a$11$.YNjmYh6nR/mCNk.GJEYj.fqICYTZAtWAbh9DhynpydaMtyfp9dLm" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "JoindedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 10, 15, 57, 44, 917, DateTimeKind.Local).AddTicks(2546), "$2a$11$7YZODrCF2bf0xps2eARDmOjkYy56dJSJDs8x3ti2SK.Pa1p8IWizS" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "JoindedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 10, 15, 57, 45, 106, DateTimeKind.Local).AddTicks(779), "$2a$11$JJ0M32yuuX20EUDvnBxGU.6h7I710mHRtledvjxBW7YLFAX3Aa8FS" });
        }
    }
}
