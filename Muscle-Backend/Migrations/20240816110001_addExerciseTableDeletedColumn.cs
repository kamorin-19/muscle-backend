﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Muscle_Backend.Migrations
{
    /// <inheritdoc />
    public partial class addExerciseTableDeletedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Exercises",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Exercises");
        }
    }
}
