using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dapr.Workflow.Starter.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2023, 11, 7, 19, 44, 41, 750, DateTimeKind.Local).AddTicks(4436), new DateTime(2023, 11, 7, 19, 44, 41, 750, DateTimeKind.Local).AddTicks(4458) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2023, 11, 7, 19, 44, 41, 750, DateTimeKind.Local).AddTicks(4460), new DateTime(2023, 11, 7, 19, 44, 41, 750, DateTimeKind.Local).AddTicks(4460) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2023, 11, 7, 19, 44, 41, 750, DateTimeKind.Local).AddTicks(4461), new DateTime(2023, 11, 7, 19, 44, 41, 750, DateTimeKind.Local).AddTicks(4462) });
        }
    }
}
