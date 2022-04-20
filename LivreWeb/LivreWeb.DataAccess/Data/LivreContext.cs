using LivreWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LivreWeb.DataAccess
{
    public class LivreContext : IdentityDbContext
    {
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<CouvertureType> CouvertureTypes { get; set; }
        public DbSet<Livre> Livres { get; set; }


        public LivreContext(DbContextOptions options) : base(options)
        {
        }
    }
}
