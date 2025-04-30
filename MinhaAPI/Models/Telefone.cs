using MinhaAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeuProjeto.Models
{
    public class Telefone
    {
        [Key]
        public int TelefoneId { get; set; }

        [Required]
        [StringLength(20)]
        public string Numero { get; set; }

        [Required]
        [StringLength(20)]
        public string Tipo { get; set; } // Celular, Residencial, Comercial, etc.

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        public Usuario? Usuario { get; set; } // Relacionamento com a classe Usuario
    }
}
