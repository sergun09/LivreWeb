using LivreWeb.DataAccess.Repository.Interfaces;
using LivreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivreWeb.DataAccess.Repository
{
    public class EntrepriseRepository : GenericRepository<Entreprise>, IEntrepriseRepository
    {
        private readonly LivreContext _context;

        public EntrepriseRepository(LivreContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Entreprise entreprise)
        {
            this._dbSet.Update(entreprise);
        }
    }
}
