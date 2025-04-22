using System.ComponentModel.DataAnnotations;

namespace OficinaAPI.Models
{
    public class RelatorioEstatistica
    {
        [Key]
        public int IDRegistro { get; set; }
        public int IDRelatorio { get; set; }
        public int IDPagamento { get; set; }
        public string TipoRegistro { get; set; }
        public DateTime DataRegistro { get; set; }
        public string Responsavel { get; set; }
        public string Departamento { get; set; }
        public string DadosRegistro { get; set; }
        public string ResultadosAnalises { get; set; }
        public string Observacoes { get; set; }
        public string ArquivoAnexado { get; set; }
        public string StatusRegistro { get; set; }
        public string Destinatario { get; set; }
    }
}
