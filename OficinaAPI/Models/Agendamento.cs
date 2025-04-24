using System.ComponentModel.DataAnnotations;

namespace OficinaAPI.Models
{
    public class Agendamento
    {
        [Key]
        public int TempoMaoDeObraID { get; set; }
        public int ReparacaoID { get; set; }
        public int FuncionarioID { get; set; }
        public int TempoGastoEmHoras { get; set; } 
        public decimal ValorMaoDeObra { get; set; } 
    }
}
