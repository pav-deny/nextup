using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextUp.Migrations
{
    /// <inheritdoc />
    public partial class SeedGlobalCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ColorHex", "Name" },
                values: new object[] { 1, "#D1D1D1", "Global" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
