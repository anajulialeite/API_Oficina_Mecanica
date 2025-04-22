using System.ComponentModel.DataAnnotations;

namespace OficinaAPI.Models
{
    public class Agendamento
    {
        [Key]
        public int IDAgendamento { get; set; }
        public int VeiculoID { get; set; }
        public DateTime DataHoraAgendamento { get; set; }
        public string Status { get; set; }
    }
}
