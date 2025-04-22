using System.ComponentModel.DataAnnotations;

namespace OficinaAPI.Models
{
    public class Contato
    {
        [Key]
        public int IDCliente { get; set; }
        public int IDFuncionario { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Morada { get; set; }
    }
}
