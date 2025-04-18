namespace OficinaAPI.Models
{
    public class FeedbackCliente
    {
        public int FeedbackClienteId { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataHora { get; set; }
        public string Avaliacoes { get; set; }
        public string Comentario { get; set; }
        public string ServicoAvaliado { get; set; }
        public string respostaDaOficina { get; set; }
        public string StatusDoFeedback { get; set; }
        public string CanalDoFeedback { get; set; }
        public string AcaoTomada { get; set; }
    }
}
