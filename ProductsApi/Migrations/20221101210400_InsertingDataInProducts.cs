using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApi.Migrations
{
    public partial class InsertingDataInProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "Description", "ImagePath", "Manufacturer", "Name", "OnStock", "Vat" },
                values: new object[] { 1, "123", "Very nice biscuit", null, "Amazon", "Biscuit", "On stock", "20" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
