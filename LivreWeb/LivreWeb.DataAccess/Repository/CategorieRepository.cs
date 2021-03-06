using LivreWeb.DataAccess.Repository.Interfaces;
using LivreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivreWeb.DataAccess.Repository
{
    public class CategorieRepository : GenericRepository<Category>, ICategorieRepository
    {
        private readonly LivreContext _context;

        public CategorieRepository(LivreContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category categorie)
        {
            this._dbSet.Update(categorie);
        }
    }
}
