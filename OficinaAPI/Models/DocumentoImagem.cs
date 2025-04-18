namespace OficinaAPI.Models
{
    public class DocumentoImagem
    {
        public int DocumentoImagemId { get; set; }
        public int VeiculoID { get; set; }
        public string NomeArquivo { get; set; }
        public string TipoDocumentoImagem { get; set; }
        public DateTime DataEnvioCriacao { get; set; }
        public string Descricao { get; set; }
        public string Arquivo { get; set; }
        public string Status { get; set; }
    }
}
