namespace OficinaAPI.Models
{
    public class ControleDePermissao
    {
        public int FuncionarioID { get; set; }
        public string NomeDoUsuario { get; set; }
        public string Cargo { get; set; }
        public string Senha { get; set; }
        public string NivelDeAcesso { get; set; }
        public string Departamento { get; set; }
        public DateTime DataEHoraDeAcesso { get; set; }
        public string OperacoesRealizadas { get; set; }
        public string ResultadoDaOperacao { get; set; }
        public string IPDeAcesso { get; set; }
        public string AcaoDeBloqueio { get; set; }
        public string Observacoes { get; set; }
    }
}
