using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersItems_Orders_OrderId",
                table: "OrdersItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersItems_Products_ProductId",
                table: "OrdersItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersItems",
                table: "OrdersItems");

            migrationBuilder.RenameTable(
                name: "OrdersItems",
                newName: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "Orders",
                newName: "IsComplete");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersItems_ProductId",
                table: "OrderItems",
                newName: "IX_OrderItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersItems_OrderId",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderId");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SellerId",
                table: "OrderItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrdersItems");

            migrationBuilder.RenameColumn(
                name: "IsComplete",
                table: "Orders",
                newName: "IsAvailable");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrdersItems",
                newName: "IX_OrdersItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrdersItems",
                newName: "IX_OrdersItems_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersItems",
                table: "OrdersItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersItems_Orders_OrderId",
                table: "OrdersItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersItems_Products_ProductId",
                table: "OrdersItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
