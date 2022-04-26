using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace LivreWeb.Models
{
    public partial class Panier
    {
        public int Id { get; set; }
        public string Quantite { get; set; } = null!;
        public string UtilisateurId { get; set; } = null!;
        public int LivreId { get; set; }

        [ValidateNever]
        public virtual Livre Livre { get; set; } = null!;

        [ValidateNever]
        public virtual Utilisateur Utilisateur { get; set; } = null!;
    }
}
