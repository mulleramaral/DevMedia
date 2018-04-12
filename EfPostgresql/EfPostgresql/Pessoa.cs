using System.ComponentModel.DataAnnotations.Schema;

namespace EfPostgresql
{
    [Table("pessoa")]
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
