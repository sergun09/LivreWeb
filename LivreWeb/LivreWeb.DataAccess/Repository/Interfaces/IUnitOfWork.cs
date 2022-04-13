using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivreWeb.DataAccess.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        CategorieRepository CategorieRepository { get; }
        CouvertureTypeRepository CouvertureTypeRepository { get; }

        Task SaveChanges();
    }
}
