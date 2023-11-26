using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dapr.Workflow.Starter.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "PaymentDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2023, 11, 11, 18, 23, 43, 147, DateTimeKind.Local).AddTicks(5408), new DateTime(2023, 11, 11, 18, 23, 43, 147, DateTimeKind.Local).AddTicks(5418) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2023, 11, 11, 18, 23, 43, 147, DateTimeKind.Local).AddTicks(5419), new DateTime(2023, 11, 11, 18, 23, 43, 147, DateTimeKind.Local).AddTicks(5420) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2023, 11, 11, 18, 23, 43, 147, DateTimeKind.Local).AddTicks(5421), new DateTime(2023, 11, 11, 18, 23, 43, 147, DateTimeKind.Local).AddTicks(5422) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "PaymentDetails");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2023, 11, 10, 10, 7, 20, 795, DateTimeKind.Local).AddTicks(9260), new DateTime(2023, 11, 10, 10, 7, 20, 795, DateTimeKind.Local).AddTicks(9272) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2023, 11, 10, 10, 7, 20, 795, DateTimeKind.Local).AddTicks(9274), new DateTime(2023, 11, 10, 10, 7, 20, 795, DateTimeKind.Local).AddTicks(9274) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2023, 11, 10, 10, 7, 20, 795, DateTimeKind.Local).AddTicks(9275), new DateTime(2023, 11, 10, 10, 7, 20, 795, DateTimeKind.Local).AddTicks(9276) });
        }
    }
}
