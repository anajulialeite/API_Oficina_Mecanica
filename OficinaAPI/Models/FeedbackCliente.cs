using System.ComponentModel.DataAnnotations;

namespace OficinaAPI.Models
{
    public class FeedbackCliente
    {
        [Key]
        public int IDFeedback { get; set; }
        public int IDCliente { get; set; }
        public DateTime DataEHora { get; set; }
        public string Avaliacoes { get; set; }
        public string Comentario { get; set; }
        public string ServicoAvaliado { get; set; }
        public string RespostaDaOficina { get; set; }
        public string StatusDoFeedback { get; set; }
        public string CanalDoFeedback { get; set; }
        public string AcaoTomada { get; set; }
    }
}
