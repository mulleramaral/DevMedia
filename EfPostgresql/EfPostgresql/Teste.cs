using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfPostgresql
{
    [Table("teste")]
    public class Teste
    {
        [Key()]
        public int Id { get; set; }
    }
}
