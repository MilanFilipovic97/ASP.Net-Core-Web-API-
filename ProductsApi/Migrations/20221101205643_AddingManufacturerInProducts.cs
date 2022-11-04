using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApi.Migrations
{
    public partial class AddingManufacturerInProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Products");
        }
    }
}
