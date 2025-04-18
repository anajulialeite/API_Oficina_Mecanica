namespace OficinaAPI.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNacimento { get; set; }
        public string Genero { get; set; }
        public string CPF { get; set; }
        public string EstadoCivil { get; set; }
        public string Observacoes { get; set; }
    }
}
