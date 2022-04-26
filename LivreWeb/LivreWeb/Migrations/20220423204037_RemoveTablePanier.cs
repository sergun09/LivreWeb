using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivreWeb.Migrations
{
    public partial class RemoveTablePanier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paniers_AspNetUsers_UtilisateurId",
                table: "Paniers");

            migrationBuilder.DropForeignKey(
                name: "FK_Paniers_Livres_LivreId",
                table: "Paniers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Paniers",
                table: "Paniers");

            migrationBuilder.RenameTable(
                name: "Paniers",
                newName: "Panier");

            migrationBuilder.RenameIndex(
                name: "IX_Paniers_UtilisateurId",
                table: "Panier",
                newName: "IX_Panier_UtilisateurId");

            migrationBuilder.RenameIndex(
                name: "IX_Paniers_LivreId",
                table: "Panier",
                newName: "IX_Panier_LivreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Panier",
                table: "Panier",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Panier_AspNetUsers_UtilisateurId",
                table: "Panier",
                column: "UtilisateurId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Panier_Livres_LivreId",
                table: "Panier",
                column: "LivreId",
                principalTable: "Livres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Panier_AspNetUsers_UtilisateurId",
                table: "Panier");

            migrationBuilder.DropForeignKey(
                name: "FK_Panier_Livres_LivreId",
                table: "Panier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Panier",
                table: "Panier");

            migrationBuilder.RenameTable(
                name: "Panier",
                newName: "Paniers");

            migrationBuilder.RenameIndex(
                name: "IX_Panier_UtilisateurId",
                table: "Paniers",
                newName: "IX_Paniers_UtilisateurId");

            migrationBuilder.RenameIndex(
                name: "IX_Panier_LivreId",
                table: "Paniers",
                newName: "IX_Paniers_LivreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paniers",
                table: "Paniers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Paniers_AspNetUsers_UtilisateurId",
                table: "Paniers",
                column: "UtilisateurId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paniers_Livres_LivreId",
                table: "Paniers",
                column: "LivreId",
                principalTable: "Livres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
