using projetoXYZ.Enumeradores;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace projetoXYZ.Models
{
    [Table("Parcelamentos")]
    public class Parcelamentos
    {
        [Key]
        public int Id { get; set; }
        public int ContasPagarId { get; set; }
        [ForeignKey(nameof(ContasPagarId))]
        public virtual ContasPagar ContasPagar { get; set; }
        public string DescParcelamento { get; set; }
        public DateTime DataCompra { get; set; }
        public double ValorCompra { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public int QtdParcelas { get; set; }
    }
}
