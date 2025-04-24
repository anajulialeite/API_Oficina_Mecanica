using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaAPI.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string? Nome { get; set; }

        public DateTime? DataNascimento { get; set; }

        public string? Genero { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string CPF { get; set; }

        public string? EstadoCivil { get; set; }

        public string? Observacao { get; set; }
    }
}
