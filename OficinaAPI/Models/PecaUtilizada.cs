using System.ComponentModel.DataAnnotations;

namespace OficinaAPI.Models
{
    public class PecaUtilizada
    {
        [Key]
        public int PecaID { get; set; }
        public int ReparacaoID { get; set; }
        public string CodigoPeca {get; set;}
        public string Designacao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}
