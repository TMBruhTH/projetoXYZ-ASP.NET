using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetoXYZ.Models
{
    [Table("Cartao")]
    public class Cartao
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NomeCartao { get; set; }
        public ContasPagar ContasPagar { get; set; }
    }
}
