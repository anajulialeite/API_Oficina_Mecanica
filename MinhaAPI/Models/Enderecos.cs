using MinhaAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeuProjeto.Models
{
    public class Enderecos
    {
        [Key]
        public int EnderecoId { get; set; }
        public string Rua { get; set; }
        public int? Numero { get; set; }
        public string? Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }

        // Relacionamento com o Usuario (opcional)
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }
    }
}

