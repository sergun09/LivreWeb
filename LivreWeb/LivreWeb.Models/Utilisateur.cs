using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivreWeb.Models
{
    // Classe permettant d'ajouter plus d'attributs à un User
    public class Utilisateur : IdentityUser
    {
        [Required]
        public string Nom { get; set; }
        public string? Adresse { get; set; }
        public string? Ville { get; set; }
        public string? Departement { get; set; }
        public string? CodePostal { get; set; }

        [ValidateNever]
        public List<Panier> Paniers { get; set; }
    }
}
