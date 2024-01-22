using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetoXYZ.Models
{
    [Table("UsuarioCompra")]
    public class UsuarioCompra
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NomeUsuario { get; set; }
        public virtual ContasPagar ContasPagar { get; set; }
    }
}
