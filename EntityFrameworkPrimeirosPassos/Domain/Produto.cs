using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string Nome { get; set; }
        [MaxLength(2000)]
        public string Descricao { get; set; }
        [Range(-999999999.999, 999999999.999)]
        public decimal Valor { get; set; }

        [ForeignKey("Loja")]
        public int LojaId { get; set; }

        public virtual Loja Loja { get; set; }

    }
}
