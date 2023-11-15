using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddJobTestSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CompanyId", "JobTitle", "Location_City", "Location_Country", "Salary_Amount", "Salary_Currency" },
                values: new object[] { 1, 1, "Test Job", "Test City", "UK", 20.0m, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
