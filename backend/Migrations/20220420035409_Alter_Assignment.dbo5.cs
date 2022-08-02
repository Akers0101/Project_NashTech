using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class Alter_Assignmentdbo5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 1,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 20, 10, 54, 8, 724, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 2,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 20, 10, 54, 8, 724, DateTimeKind.Local).AddTicks(9852));

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 3,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 20, 10, 54, 8, 724, DateTimeKind.Local).AddTicks(9854));

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "AssignmentId",
                keyValue: 2,
                column: "AssignedDate",
                value: new DateTime(2022, 4, 20, 10, 54, 9, 312, DateTimeKind.Local).AddTicks(4230));

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "AssignmentId",
                keyValue: 3,
                column: "AssignedDate",
                value: new DateTime(2022, 4, 20, 10, 54, 9, 312, DateTimeKind.Local).AddTicks(4249));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "JoinedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 20, 10, 54, 8, 922, DateTimeKind.Local).AddTicks(9287), "$2a$11$4Rpe6Vz/3aIvJJY10P0LiOlUvlA1jO5.d9puDodZbK1ENewDbIgRS" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "JoinedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 20, 10, 54, 9, 117, DateTimeKind.Local).AddTicks(8201), "$2a$11$iLtV8uiKmZHuo9VoNTYKKuTPhOLwt4py4obRGe8DwE1txixVDPh2W" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "JoinedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 20, 10, 54, 9, 312, DateTimeKind.Local).AddTicks(3735), "$2a$11$4bG7esMGAsCDwMpYyX26aOOa7qL4Vc/KgNqrEVX2l9D6tOUPMs2le" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 1,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 19, 18, 3, 2, 713, DateTimeKind.Local).AddTicks(4831));

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 2,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 19, 18, 3, 2, 713, DateTimeKind.Local).AddTicks(4887));

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 3,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 19, 18, 3, 2, 713, DateTimeKind.Local).AddTicks(4897));

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "AssignmentId",
                keyValue: 2,
                column: "AssignedDate",
                value: new DateTime(2022, 4, 19, 18, 3, 3, 293, DateTimeKind.Local).AddTicks(5714));

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "AssignmentId",
                keyValue: 3,
                column: "AssignedDate",
                value: new DateTime(2022, 4, 19, 18, 3, 3, 293, DateTimeKind.Local).AddTicks(5731));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "JoinedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 19, 18, 3, 2, 908, DateTimeKind.Local).AddTicks(395), "$2a$11$f4iw372owt.mV4T0jMDd2O1EncPVNlvetsTSvU/EIKZs.B/4vzCyu" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "JoinedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 19, 18, 3, 3, 101, DateTimeKind.Local).AddTicks(1324), "$2a$11$lc0Od0XFVmGdT8VxHu/cRu3LbRwKSJaR3VL0j5a7vp2CssJgXoKru" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "JoinedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 4, 19, 18, 3, 3, 293, DateTimeKind.Local).AddTicks(5241), "$2a$11$k5e/og4q6r.gxjVLGEIzGeFuyX7V7dzl6vqozFicHHaocgWoDho6q" });
        }
    }
}
