using System.ComponentModel.DataAnnotations;

namespace Clinica.Models
{
    public class Dono
    {


        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe sua Categoria")]
        public string Categoria { get; set; }
        [Required(ErrorMessage = "Informe seu Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe seu Celular")]
        [MinLength(8)]
        public string Celular { get; set; }



    }
}
