using Domain;
using System.Data.Entity;

namespace Data
{
    public class Contexto : DbContext
    {
        public Contexto() : base("Db")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Contexto>());
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Loja> Lojas { get; set; }
    }
}
