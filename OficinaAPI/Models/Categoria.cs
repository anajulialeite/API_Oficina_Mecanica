using System.ComponentModel.DataAnnotations;

namespace OficinaAPI.Models
{
    public class Categoria
    {
        [Key]
        public int IDCategoria { get; set; }
        public int ClienteID { get; set; }
        public int FuncionarioID { get; set; }
        public decimal CustoHora { get; set; }

    }
}
