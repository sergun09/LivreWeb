using LivreWeb.DataAccess.Repository.Interfaces;
using LivreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivreWeb.DataAccess.Repository
{
    public class CouvertureTypeRepository : GenericRepository<CouvertureType>, ICouvertureTypeRepository
    {
        private readonly LivreContext _context;

        public CouvertureTypeRepository(LivreContext context) : base(context)
        {
            _context = context;
        }

        public void Update(CouvertureType couvertureType)
        {
            this._dbSet.Update(couvertureType);
        }
    }
}
