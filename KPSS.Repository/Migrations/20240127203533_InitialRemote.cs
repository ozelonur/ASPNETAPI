using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPSS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialRemote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 23, 35, 33, 918, DateTimeKind.Local).AddTicks(5050));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 23, 35, 33, 918, DateTimeKind.Local).AddTicks(5130));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 23, 35, 33, 918, DateTimeKind.Local).AddTicks(5130));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 23, 35, 33, 918, DateTimeKind.Local).AddTicks(5130));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 1, 0, 33, 528, DateTimeKind.Local).AddTicks(9660));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 1, 0, 33, 528, DateTimeKind.Local).AddTicks(9680));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 1, 0, 33, 528, DateTimeKind.Local).AddTicks(9690));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 1, 0, 33, 528, DateTimeKind.Local).AddTicks(9690));
        }
    }
}
