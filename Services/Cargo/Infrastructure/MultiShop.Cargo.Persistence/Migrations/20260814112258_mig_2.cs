using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiShop.Cargo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserCustomerId",
                table: "cargoCustomerCompanies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserCustomerId",
                table: "cargoCustomerCompanies");
        }
    }
}
