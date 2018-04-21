using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("loja")]
    public class Loja
    {
        public Loja()
        {
            Produtos = new List<Produto>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }
        [MaxLength(2000)]
        public string Descricao { get; set; }

        public virtual List<Produto> Produtos { get; set; }
    }
}
