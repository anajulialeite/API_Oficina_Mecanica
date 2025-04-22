using System.ComponentModel.DataAnnotations;

namespace OficinaAPI.Models
{
    public class PecaEmArmazem
    {
        [Key]
        public int PecaEmArmazemID { get; set; }
        public string CodigoPeca { get; set; }
        public string Descricao { get; set; }
        public decimal CustoUnitario { get; set; }
        public int QuantidadeAtual { get; set; }
        public int PecaID { get; set; }
    }
}
