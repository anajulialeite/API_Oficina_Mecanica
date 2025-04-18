namespace OficinaAPI.Models
{
    public class Reparacao
    {
        public int ReparacaoId { get; set; }
        public int VeiculoId { get; set; }
        public DateTime DataReparacao { get; set; }
        public decimal CustoTotal { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public string Observacoes { get; set; }
    }
}
