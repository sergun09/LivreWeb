using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivreWeb.DataAccess.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        ICategorieRepository CategorieRepository { get; }
        ICouvertureTypeRepository CouvertureTypeRepository { get; }
        ILivreRepository LivreRepository { get; }
        IEntrepriseRepository EntrepriseRepository{ get; }
        Task SaveChanges();
    }
}
