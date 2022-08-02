using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class Alter_Assetdbo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Asset_AssetId",
                table: "Assignment");

            migrationBuilder.DropTable(
                name: "ReturningRequest");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_AssetId",
                table: "Assignment");

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

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_AssetId",
                table: "Assignment",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Asset_AssetId",
                table: "Assignment",
                column: "AssetId",
                principalTable: "Asset",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Asset_AssetId",
                table: "Assignment");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_AssetId",
                table: "Assignment");

            migrationBuilder.CreateTable(
                name: "ReturningRequest",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    ProcessedByUserId = table.Column<int>(type: "int", nullable: false),
                    RequestedByUserId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 1,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 17, 15, 53, 22, 691, DateTimeKind.Local).AddTicks(5446));

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 2,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 17, 15, 53, 22, 691, DateTimeKind.Local).AddTicks(5465));

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 3,
                column: "InstalledDate",
                value: new DateTime(2022, 4, 17, 15, 53, 22, 691, DateTimeKind.Local).AddTicks(5467));

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "AssignmentId",
                keyValue: 2,
                column: "AssignedDate",
                value: new DateTime(2022, 4, 17, 15, 53, 23, 275, DateTimeKind.Local).AddTicks(29));

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "AssignmentId",
                keyValue: 3,
                column: "AssignedDate",
                value: new DateTime(2022, 4, 17, 15, 53, 23, 275, DateTimeKind.Local).AddTicks(46));

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

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_AssetId",
                table: "Assignment",
                column: "AssetId",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Asset_AssetId",
                table: "Assignment",
                column: "AssetId",
                principalTable: "Asset",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
