using LivreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivreWeb.DataAccess.Repository.Interfaces
{
    public interface IEntrepriseRepository : IGenericRepository<Entreprise>
    {
        // Signatures des méthodes propres à chaque modèle
       void Update(Entreprise entreprise);
    }
}
