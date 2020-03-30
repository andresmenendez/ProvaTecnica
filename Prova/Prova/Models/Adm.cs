using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Prova.Models
{
    [Table("tbAdm")]
    public class Adm
    {
        [Key]
        public int IdAdm { get; set; }

        [Display(Name = "Administradora")]
        [Required(ErrorMessage = "O nome da administradora é obrigatório", AllowEmptyStrings = false)]
        public string NomeAdm { get; set; }
    }
}