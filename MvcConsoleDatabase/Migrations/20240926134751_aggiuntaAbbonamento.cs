using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcConsoleDatabase.Migrations
{
    /// <inheritdoc />
    public partial class aggiuntaAbbonamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stato",
                table: "Users",
                newName: "isActive");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Users",
                newName: "Stato");
        }
    }
}
