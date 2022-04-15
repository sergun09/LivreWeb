using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivreWeb.Migrations
{
    public partial class LivreTableRenameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "Livres",
                newName: "Titre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titre",
                table: "Livres",
                newName: "Nom");
        }
    }
}
