using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class Alter_Userdbo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Location",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                columns: new[] { "JoindedDate", "Location", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 10, 15, 57, 44, 728, DateTimeKind.Local).AddTicks(3811), 0, "$2a$11$.YNjmYh6nR/mCNk.GJEYj.fqICYTZAtWAbh9DhynpydaMtyfp9dLm" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "JoindedDate", "Location", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 10, 15, 57, 44, 917, DateTimeKind.Local).AddTicks(2546), 0, "$2a$11$7YZODrCF2bf0xps2eARDmOjkYy56dJSJDs8x3ti2SK.Pa1p8IWizS" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "JoindedDate", "Location", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 10, 15, 57, 45, 106, DateTimeKind.Local).AddTicks(779), 1, "$2a$11$JJ0M32yuuX20EUDvnBxGU.6h7I710mHRtledvjxBW7YLFAX3Aa8FS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 1,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 5, 8, 14, 33, 529, DateTimeKind.Local).AddTicks(810));

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 2,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 5, 8, 14, 33, 529, DateTimeKind.Local).AddTicks(825));

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 3,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 5, 8, 14, 33, 529, DateTimeKind.Local).AddTicks(826));

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "AssignmentId",
                keyValue: 1,
                column: "AssignedDate",
                value: new DateTime(2022, 4, 5, 8, 14, 34, 54, DateTimeKind.Local).AddTicks(4206));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "JoindedDate", "Location", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 5, 8, 14, 33, 700, DateTimeKind.Local).AddTicks(4116), "Ha Noi", "$2a$11$TcTBPgRfsxbOnLlMSpBIvufb1LU9fn31NiHEC6cJe6jp77xYoleay" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "JoindedDate", "Location", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 5, 8, 14, 33, 870, DateTimeKind.Local).AddTicks(6839), "Bac Giang", "$2a$11$5sGofnayV8S.haZ69VMwKexwA7wcbOFZ9JaSrN1QcYTD1UzoDy2Ra" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "JoindedDate", "Location", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 5, 8, 14, 34, 54, DateTimeKind.Local).AddTicks(3791), "Cao Bang", "$2a$11$Vh8sdbkegu4PoNLWtOZmDeJ7MlPKP1oNcqIY14JkG7fkClAYV6LMS" });
        }
    }
}
