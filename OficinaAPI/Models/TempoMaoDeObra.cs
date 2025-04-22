using System.ComponentModel.DataAnnotations;

namespace OficinaAPI.Models
{
    public class TempoMaoDeObra
    {
        [Key]
        public int TempoMaoDeObraID { get; set; }
        public int ReparacaoID { get; set; }
        public int FuncionarioID { get; set; }
        public int TempoGasto { get; set; }

    }
}
