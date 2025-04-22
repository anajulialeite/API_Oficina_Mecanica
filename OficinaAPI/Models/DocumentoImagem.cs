using System.ComponentModel.DataAnnotations;

namespace OficinaAPI.Models
{
    public class DocumentoImagem
    {
        [Key]
        public int IDDocumentoImagem { get; set; }
        public int IDVeiculo { get; set; }
        public string NomeArquivo { get; set; }
        public string TipoDocumentoImagem { get; set; }
        public DateTime DataEnvioCriacao { get; set; }
        public string Descricao { get; set; }
        public string Arquivo { get; set; }
        public string Status { get; set; }
    }
}
