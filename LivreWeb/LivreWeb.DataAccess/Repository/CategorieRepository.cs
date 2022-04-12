using LivreWeb.DataAccess.Repository.Interfaces;
using LivreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivreWeb.DataAccess.Repository
{
    public class CategorieRepository : GenericRepository<Categorie>, ICategorieRepository
    {
        private readonly LivreContext _context;

        public CategorieRepository(LivreContext context) : base(context)
        {
            _context = context;
        }

        public async Task SaveChanges()
        {
            await this._context.SaveChangesAsync();
        }

        public void Update(Categorie categorie)
        {
            this._dbSet.Update(categorie);
        }
    }
}
