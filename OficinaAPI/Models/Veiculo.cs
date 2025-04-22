using System.ComponentModel.DataAnnotations;
using System.IO.Pipes;

namespace OficinaAPI.Models
{
    public class Veiculo
    {
        [Key]
        public int VeiculoID { get; set; }
        public int ClienteID { get; set; }
        public string Modelo { get; set; }
        public short AnoFabricacao {get; set;}
        public string Chassi { get; set; }
        public int Quilometragem { get; set; }
        public string Placa { get; set; }
        public DateTime DataAquisição { get; set; }
    }
}
