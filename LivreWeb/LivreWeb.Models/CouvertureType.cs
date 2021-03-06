using System;
using System.Collections.Generic;

namespace LivreWeb.Models
{
    public partial class CouvertureType
    {
        public CouvertureType()
        {
            Livres = new HashSet<Livre>();
        }

        public int Id { get; set; }
        public string Nom { get; set; } = null!;

        public virtual ICollection<Livre> Livres { get; set; }
    }
}
