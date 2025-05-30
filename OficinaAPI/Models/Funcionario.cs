﻿using System.ComponentModel.DataAnnotations;

namespace OficinaAPI.Models
{
    public class Funcionario
    {
        [Key]
        public int FuncionarioID { get; set; }
        public string Name { get; set; }
        public string Categoria { get; set; }
        public DateTime DataContratacao { get; set; }
        public decimal Salario { get; set; }
        public string ContatoEmergencia { get; set; }
        public string Qualificacoes { get; set; }
     }
}
