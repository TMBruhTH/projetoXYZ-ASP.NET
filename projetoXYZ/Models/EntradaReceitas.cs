using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetoXYZ.Models
{
    [Table("EntradaReceitas")]
    public class EntradaReceitas
    {
        [Key]
        public int Id { get; set; }
        public double PagamentoHeloiza { get; set; }
        public double ValeHeloiza { get; set; }
        public double PagamentoBruno_InfoSys { get; set; }
        public double PagamentoBruno_Sinapse { get; set; }
        public double Extras { get; set; }
        public double Reembolsos { get; set; }
    }
}
