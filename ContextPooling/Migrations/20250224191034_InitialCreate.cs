using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContextPooling.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Price", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, "John Doe", 29.99m, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C# Programming" },
                    { 2, "Jane Smith", 49.99m, new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entity Framework Core" },
                    { 3, "James Brown", 39.99m, new DateTime(2022, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Core for Beginners" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
