using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi1.Migrations
{
    /// <inheritdoc />
    public partial class Migration14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OrderId1",
                table: "OrderProducts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId1",
                table: "OrderProducts",
                column: "OrderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Orders_OrderId1",
                table: "OrderProducts",
                column: "OrderId1",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Orders_OrderId1",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_OrderId1",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "OrderProducts");
        }
    }
}
