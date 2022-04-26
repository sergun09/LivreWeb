using System;
using System.Collections.Generic;

namespace LivreWeb.Models
{
    public partial class Category
    {
        public Category()
        {
            Livres = new HashSet<Livre>();
        }

        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        public int NombreCommandes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<Livre> Livres { get; set; }
    }
}
