using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivreWeb.Models
{
    public class Livre
    {
        public int Id { get; set; }
        
        [Required]
        public string Titre { get; set; } = string.Empty;
        
        [Required]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        public string ISBN { get; set; } = string.Empty;
        
        [Required]
        public string Auteur { get; set; } = string.Empty;
        
        [Required]
        [Range(1, 1000)]
        public double Prix { get; set; }
       
        [ValidateNever]
        public string ImageUrl { get; set; } = string.Empty;

        [ValidateNever]
        public Categorie? Categorie { get; set; }

        [Display(Name = "Catégorie")]
        public int CategorieId { get; set; }

        [ValidateNever]
        public CouvertureType? CouvertureType { get; set; }
        
        [Display(Name = "Type de Couverture")]
        public int CouvertureTypeId { get; set; }



    }
}
