using LivreWeb.DataAccess.Repository.Interfaces;
using LivreWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivreWeb.DataAccess.Repository
{
    public class LivreRepository : GenericRepository<Livre>, ILivreRepository
    {
        private readonly LivreContext _context;

        public LivreRepository(LivreContext context) : base(context)
        {
            this._context = context;
        }

        public void Update(Livre livre)
        {
            this._dbSet.Update(livre);
        }
    }
}
