
using System.Data.Entity;

namespace Prova.Models
{
    public class ProvaDbContext : DbContext
    {
        public DbSet<Adm> Adms { get; set; }
        public DbSet<Condominio> Condominios { get; set; }
        public DbSet<User> Users { get; set; }
        
    }
}