using LivreWeb.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivreWeb.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private LivreContext _context;

        public ICategorieRepository CategorieRepository { get; set; }
        public ICouvertureTypeRepository CouvertureTypeRepository { get; set; }
        public ILivreRepository LivreRepository { get; set; }

        public UnitOfWork(LivreContext context)
        {
            _context = context;
            this.CategorieRepository = new CategorieRepository(this._context);
            this.CouvertureTypeRepository = new CouvertureTypeRepository(this._context);
            this.LivreRepository = new LivreRepository(this._context);
        }

        public async Task SaveChanges()
        {
            await this._context.SaveChangesAsync();
        }
    }
}
