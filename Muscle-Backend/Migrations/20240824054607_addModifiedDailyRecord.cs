using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Muscle_Backend.Migrations
{
    /// <inheritdoc />
    public partial class addModifiedDailyRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyRecords",
                columns: table => new
                {
                    DailyRecordId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EnforcementDay = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    ExercisePId = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstSetCount = table.Column<int>(type: "INTEGER", nullable: false),
                    SecondSetCount = table.Column<int>(type: "INTEGER", nullable: false),
                    ThirdSetCount = table.Column<int>(type: "INTEGER", nullable: false),
                    FourthSetCount = table.Column<int>(type: "INTEGER", nullable: false),
                    FifthSetCount = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyRecords", x => x.DailyRecordId);
                    table.ForeignKey(
                        name: "FK_DailyRecords_Exercises_ExercisePId",
                        column: x => x.ExercisePId,
                        principalTable: "Exercises",
                        principalColumn: "ExercisePId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyRecords_ExercisePId",
                table: "DailyRecords",
                column: "ExercisePId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyRecords");
        }
    }
}
