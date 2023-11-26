using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dapr.Workflow.Starter.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "UnitCost",
                table: "Products",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "Total",
                table: "Orders",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "Tax",
                table: "Orders",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "Actual_Cost",
                table: "Orders",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CardHolderName = table.Column<string>(type: "TEXT", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ProductDescription", "ProductName", "UnitCost" },
                values: new object[,]
                {
                    { 1, "Pen that marks", "Mark O Pen", 10.99 },
                    { 2, "Gel that marks", "Mark O Gel", 10.99 },
                    { 3, "Copy that marks", "Mark O Copy", 10.99 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "aps1@aps.com", "Arkaprava Sinha1" },
                    { 2, "aps2@aps.com", "Arkaprava Sinha2" },
                    { 3, "aps3@aps.com", "Arkaprava Sinha3" }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "CreatedTime", "ProductId", "UpdatedTime", "stock" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 7, 19, 44, 41, 750, DateTimeKind.Local).AddTicks(4436), 1, new DateTime(2023, 11, 7, 19, 44, 41, 750, DateTimeKind.Local).AddTicks(4458), 10 },
                    { 2, new DateTime(2023, 11, 7, 19, 44, 41, 750, DateTimeKind.Local).AddTicks(4460), 2, new DateTime(2023, 11, 7, 19, 44, 41, 750, DateTimeKind.Local).AddTicks(4460), 10 },
                    { 3, new DateTime(2023, 11, 7, 19, 44, 41, 750, DateTimeKind.Local).AddTicks(4461), 3, new DateTime(2023, 11, 7, 19, 44, 41, 750, DateTimeKind.Local).AddTicks(4462), 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentDetails_PaymentId",
                table: "Orders",
                column: "PaymentId",
                principalTable: "PaymentDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentDetails_PaymentId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "PaymentDetails");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitCost",
                table: "Products",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Tax",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Actual_Cost",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}
