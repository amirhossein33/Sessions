using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfProject.Migrations
{
    /// <inheritdoc />
    public partial class FixPaymentMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Payments",
                type: "nchar(5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(5)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Payments",
                type: "nchar(5)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nchar(5)",
                oldNullable: true);
        }
    }
}
