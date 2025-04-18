namespace OficinaAPI.Models
{
    public class Contato
    {
        public int ClienteId { get; set; }
        public int FuncionarioId { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }
        public string Morada { get; set; }
    }
}
