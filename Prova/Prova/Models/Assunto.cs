using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prova.Models
{
    public class Assunto
    {
        [Display(Name = "Morador")]
        public int IdMorador { get; set; }

        [Display(Name = "Conteúdo")]
        [Required(ErrorMessage = "O conteúdo do comunicado é obrigatório.", AllowEmptyStrings = false)]
        public string Conteudo { get; set; }

        [Display(Name = "Tipo Assunto")]
        public int TipoAssunto { get; set; }
    }
}