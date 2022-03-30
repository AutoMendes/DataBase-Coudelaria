using System.ComponentModel.DataAnnotations;

namespace Exercicio2.Models
{
    public class Cavalos
    {
        [Key]
        public int Cod_Cavalo { get; set; }
        public string Nome_Cavalo { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string Genero { get; set; }
        public int? Pai { get; set; }
        public int? Mae { get; set; }
        public int? Cod_Coudelaria_Nasc { get; set; }
        public int Cod_Coudelaria_Resid { get; set; }
        public Cavalos()
        {
        }
    }
}
