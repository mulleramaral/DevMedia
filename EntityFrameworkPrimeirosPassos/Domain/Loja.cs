using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("loja")]
    public class Loja
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
