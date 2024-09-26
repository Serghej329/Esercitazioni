using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcConsoleDatabase.Migrations
{
    /// <inheritdoc />
    public partial class AggiuntaStato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Stato",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stato",
                table: "Users");
        }
    }
}
