using LivreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivreWeb.DataAccess.Repository.Interfaces
{
    public interface ICategorieRepository : IGenericRepository<Category>
    {
        // Signatures des méthodes propres à chaque modèle
       void Update(Category categorie);
    }
}
