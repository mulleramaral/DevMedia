using System.Data.Entity;

namespace EfPostgresql
{
    public class EfContext : DbContext
    {
        public EfContext() : base("PgProdutos")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Produto> produto { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Teste> Teste { get; set; }
    }
}
