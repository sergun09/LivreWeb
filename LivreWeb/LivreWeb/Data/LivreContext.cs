using LivreWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace LivreWeb.Data
{
    public class LivreContext : DbContext
    {
        public DbSet<Categorie> Categories { get; set; }
        public LivreContext(DbContextOptions options) : base(options)
        {
        }
    }
}
