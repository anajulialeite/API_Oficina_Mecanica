using System.ComponentModel.DataAnnotations;

namespace OficinaAPI.Models
{
    public class CustoMaoDeObra
    {
        [Key]
        public int IDCustoMaoDeObra { get; set; }
        public DateTime DataPagamento { get; set; }
        public string Descricao { get; set; }
        public string TipoDePagamento { get; set; }
        public decimal Valor { get; set; }
        public string MetodoDePagamento { get; set; }
        public string NumeroDaFatura { get; set; }
        public string Fornecedor { get; set; }
        public int Funcionario { get; set; }
        public string Despesa { get; set; }
        public string Observacoes { get; set; }
    }
}
