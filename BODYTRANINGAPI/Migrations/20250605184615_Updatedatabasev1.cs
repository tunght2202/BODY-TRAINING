using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BODYTRANINGAPI.Migrations
{
    /// <inheritdoc />
    public partial class Updatedatabasev1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Access",
                table: "WorkoutPlans",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Access",
                table: "WorkoutPlans");
        }
    }
}
