using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfficeManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddPreferenceToRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Preference",
                table: "AspNetRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preference",
                table: "AspNetRoles");
        }
    }
}
