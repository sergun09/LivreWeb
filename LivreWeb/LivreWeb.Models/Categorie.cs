using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LivreWeb.Models
{
    public class Categorie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; } = string.Empty;
        public int NombreCommandes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ValidateNever]
        public List<Livre> Livres { get; set; }

    }
}
