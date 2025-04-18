namespace OficinaAPI.Models
{
    public class Agendamento
    {
        public int AgendamentoId { get; set; }
        public int VeiculoId { get; set; }
        public DateTime DataHoraAgendamento { get; set; }
        public string Status { get; set; }
    }
}
