using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class Alter_Userdbo3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JoindedDate",
                table: "User",
                newName: "JoinedDate");

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

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "AssignmentId",
                keyValue: 1,
                column: "AssignedDate",
                value: new DateTime(2022, 4, 13, 21, 12, 49, 375, DateTimeKind.Local).AddTicks(2123));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JoinedDate",
                table: "User",
                newName: "JoindedDate");

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 1,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 13, 11, 47, 28, 875, DateTimeKind.Local).AddTicks(5682));

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 2,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 13, 11, 47, 28, 875, DateTimeKind.Local).AddTicks(5709));

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 3,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 13, 11, 47, 28, 875, DateTimeKind.Local).AddTicks(5711));

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
                columns: new[] { "JoindedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 13, 11, 47, 29, 71, DateTimeKind.Local).AddTicks(671), "$2a$11$dSyLKvypV2m5IOLbdAjlH.17aRuS/xwo3U6U6Jb8khjkQZl.b3saW" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "JoindedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 13, 11, 47, 29, 265, DateTimeKind.Local).AddTicks(7631), "$2a$11$DBqOwAKfk1XX2MOX4KOrLegy8Df352WnL8JQcHqw4Dy9RGFoOQGLS" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "JoindedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 13, 11, 47, 29, 465, DateTimeKind.Local).AddTicks(2363), "$2a$11$unDoa6l5.WNHAV.gxHw5JeNiISE4IQYqxg8Wdn0y0etTwk.uN4X12" });
        }
    }
}
