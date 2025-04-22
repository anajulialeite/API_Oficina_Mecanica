using System.ComponentModel.DataAnnotations;

namespace OficinaAPI.Models
{
    public class Reparacao
    {
        [Key]
        public int ReparacaoID { get; set; }
        public int VeiculoID { get; set; }
        public int ClienteID { get; set; }
        public DateTime DataReparacao { get; set; }
        public decimal CustoTotal { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public string Observacoes { get; set; }
    }
}
