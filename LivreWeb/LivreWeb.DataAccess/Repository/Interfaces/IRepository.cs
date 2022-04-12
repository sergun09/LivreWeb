using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivreWeb.DataAccess.Repository.Interfaces
{
    public interface IRepository<T> where T : class 
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        
    }
}
