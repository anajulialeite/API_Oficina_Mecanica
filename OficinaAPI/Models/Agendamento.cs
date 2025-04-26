using System;
using System.ComponentModel.DataAnnotations;

namespace OficinaAPI.Models
{
    public class Agendamento
    {
        [Key]
        public int AgendamentoID { get; set; }

        public int ClienteID { get; set; }
        public int VeiculoID { get; set; }
        public int? FuncionarioID { get; set; } // Pode ser null

        public required DateTime DataHoraAgendada { get; set; }

        [Required(ErrorMessage = "Informe as observações")]
        public string Observacoes { get; set; }

        // Propriedades de navegação (não usar 'required' aqui)
        public Cliente Cliente { get; set; }
        public Veiculo Veiculo { get; set; }
        public Funcionario? Funcionario { get; set; } // Pode ser null
    }
}
