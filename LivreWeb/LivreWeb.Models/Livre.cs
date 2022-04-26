using System;
using System.Collections.Generic;

namespace LivreWeb.Models
{
    public partial class Livre
    {
        public Livre()
        {
            Paniers = new HashSet<Panier>();
        }

        public int Id { get; set; }
        public string Titre { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ISBN { get; set; } = null!;
        public string Auteur { get; set; } = null!;
        public double Prix { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int CategorieId { get; set; }
        public int CouvertureTypeId { get; set; }

        public virtual Category Categorie { get; set; } = null!;
        public virtual CouvertureType CouvertureType { get; set; } = null!;
        public virtual ICollection<Panier> Paniers { get; set; }
    }
}
