using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTracker.Migrations
{
    /// <inheritdoc />
    public partial class RemodelEntitiesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_JobApplications_JobApplicationId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Jobs_JobId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_JobApplications_JobApplicationId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobApplications_JobApplicationId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobApplicationId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Company_JobApplicationId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_JobId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "JobApplicationId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobApplicationId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Company");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "JobApplications",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "JobApplicationId",
                table: "Interviews",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobId",
                table: "JobApplications",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_JobApplications_JobApplicationId",
                table: "Interviews",
                column: "JobApplicationId",
                principalTable: "JobApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Jobs_JobId",
                table: "JobApplications",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_JobApplications_JobApplicationId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Jobs_JobId",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_JobId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "JobApplications");

            migrationBuilder.AddColumn<int>(
                name: "JobApplicationId",
                table: "Jobs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "JobApplicationId",
                table: "Interviews",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "JobApplicationId",
                table: "Company",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Company",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobApplicationId",
                table: "Jobs",
                column: "JobApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_JobApplicationId",
                table: "Company",
                column: "JobApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_JobId",
                table: "Company",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_JobApplications_JobApplicationId",
                table: "Company",
                column: "JobApplicationId",
                principalTable: "JobApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Jobs_JobId",
                table: "Company",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_JobApplications_JobApplicationId",
                table: "Interviews",
                column: "JobApplicationId",
                principalTable: "JobApplications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobApplications_JobApplicationId",
                table: "Jobs",
                column: "JobApplicationId",
                principalTable: "JobApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
