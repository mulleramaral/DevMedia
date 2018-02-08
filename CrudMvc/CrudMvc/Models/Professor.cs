using System.ComponentModel.DataAnnotations.Schema;

namespace CrudMvc.Models
{
    [Table("Professor")]
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}