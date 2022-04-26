using System;
using System.Collections.Generic;

namespace LivreWeb.Models
{
    public partial class Entreprise
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Adresse { get; set; }
        public string? Ville { get; set; }
        public string? Departement { get; set; }
        public string? CodePostal { get; set; }
        public string? Numero { get; set; }
    }
}
