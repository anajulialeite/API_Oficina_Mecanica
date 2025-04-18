namespace OficinaAPI.Models
{
    public class PecaUtilizada
    {
        public int PecaId { get; set; }
        public int ReparacaoId { get; set; }
        public string CodigoPeca {get; set;}
        public string Designacao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}
