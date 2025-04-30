using Microsoft.EntityFrameworkCore;
using MinhaAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace SeuProjeto.Models
{
    public class Postagem
    {
        [Key]
        public int PostagemId { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioId { get; set; }
    }
}
