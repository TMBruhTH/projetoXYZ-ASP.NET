using projetoXYZ.Enumeradores;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetoXYZ.Models
{
    [Table("ContasPagar")]
    public class ContasPagar
    {
        [Key]
        public int Id { get; set; }
        public int CartaoId { get; set; }
        [ForeignKey(nameof(CartaoId))]
        public virtual Cartao Cartao { get; set; }
        public int UsuarioCompraId { get; set; }
        [ForeignKey(nameof(UsuarioCompraId))]
        public UsuarioCompra UsuarioCompra { get; set; }
        public StatusPagamento StatusPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public DateTime DataCriacao { get; set; }
        public double? ValorTotalMes { get; set; }
        public double? ValorTotalCartao { get; set; }
        /* relacionamento um-para-muitos */
        public ICollection<Parcelamentos> Parcelamentos { get; set; }
    }
}
