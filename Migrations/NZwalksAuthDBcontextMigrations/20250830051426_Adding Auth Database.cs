using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPICodeDemo.Migrations.NZwalksAuthDBcontextMigrations
{
    /// <inheritdoc />
    public partial class AddingAuthDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bc27bcd1-286a-4d21-b2cb-9c8204489725", "bc27bcd1-286a-4d21-b2cb-9c8204489725", "Writer", "WRITER" },
                    { "c2791820-0704-429c-a4f2-d57bf9533ffe", "c2791820-0704-429c-a4f2-d57bf9533ffe", "Reader", "READER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc27bcd1-286a-4d21-b2cb-9c8204489725");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2791820-0704-429c-a4f2-d57bf9533ffe");
        }
    }
}
