using System.ComponentModel.DataAnnotations;

namespace Exercicio2.Models
{
    public class Utilizadores
    {
        [Key]
        public int Cod_Utilizador { get; set; }
        public string? Nome { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
    }
}
