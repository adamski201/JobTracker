using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddJobApplicationTestSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "Id", "Deadline", "InitialApplicationDate", "InitialDateAdvertised", "JobId", "Status" },
                values: new object[] { 1, new DateTime(2023, 11, 20, 10, 19, 23, 783, DateTimeKind.Local).AddTicks(3800), new DateTime(2023, 11, 15, 10, 19, 23, 783, DateTimeKind.Local).AddTicks(3797), new DateTime(2023, 11, 10, 10, 19, 23, 783, DateTimeKind.Local).AddTicks(3755), 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
