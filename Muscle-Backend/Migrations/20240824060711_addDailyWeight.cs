using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Muscle_Backend.Migrations
{
    /// <inheritdoc />
    public partial class addDailyWeight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyWeights",
                columns: table => new
                {
                    DailyWeightId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecordedDay = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Weight = table.Column<double>(type: "REAL", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyWeights", x => x.DailyWeightId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyWeights");
        }
    }
}
