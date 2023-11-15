using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTracker.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCompanyTableNameMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Company_CompanyId",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Deadline", "InitialApplicationDate", "InitialDateAdvertised" },
                values: new object[] { new DateTime(2023, 11, 20, 11, 59, 56, 552, DateTimeKind.Local).AddTicks(8510), new DateTime(2023, 11, 15, 11, 59, 56, 552, DateTimeKind.Local).AddTicks(8505), new DateTime(2023, 11, 10, 11, 59, 56, 552, DateTimeKind.Local).AddTicks(8452) });

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Companies_CompanyId",
                table: "Jobs",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Companies_CompanyId",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Deadline", "InitialApplicationDate", "InitialDateAdvertised" },
                values: new object[] { new DateTime(2023, 11, 20, 10, 19, 23, 783, DateTimeKind.Local).AddTicks(3800), new DateTime(2023, 11, 15, 10, 19, 23, 783, DateTimeKind.Local).AddTicks(3797), new DateTime(2023, 11, 10, 10, 19, 23, 783, DateTimeKind.Local).AddTicks(3755) });

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Company_CompanyId",
                table: "Jobs",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
