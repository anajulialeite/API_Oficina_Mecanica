namespace OficinaAPI.Models
{
    public class PecaEmArmazem
    {
        public int PecaEmArmazemId { get; set; }
        public int PecaId { get; set; }
        public string CodigoPeca { get; set; }
        public string Descricao { get; set; }
        public string CustoUnitario { get; set; }
        public int QuantidadeAtual { get; set; }
    }
}
