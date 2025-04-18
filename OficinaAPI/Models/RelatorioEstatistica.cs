namespace OficinaAPI.Models
{
    public class RelatorioEstatistica
    {
        public int RegistroId { get; set; }
        public int RelatorioId { get; set; }
        public int PagamentoId { get; set; }
        public string TipoRegistro { get; set; }
        public DateTime DataRegistro { get; set; }
        public string responsavel { get; set; }
        public string Departamento { get; set; }
        public string DadosRegistro { get; set; }
        public string ResultadosAnalises { get; set; }
        public string Observacoes { get; set; }
        public string ArquivoAnexado { get; set; }
        public string StatusRegistro { get; set; }
        public string Destinatario { get; set; }
    }
}
