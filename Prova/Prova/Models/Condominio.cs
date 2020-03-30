using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Prova.Models
{
    [Table("tbCondominio")]
    public class Condominio
    {
        [Key]
        [Column("IdCondominio")]
        public int IdCondominio { get; set; }

        [Column("IdAdm")]
        [Display(Name = "Administradora")]
        public int IdAdm { get; set; }

        [Column("NomeCondominio")]
        [Display(Name = "Nome Condominio")]
        [Required(ErrorMessage = "O nome do condomínio é obrigatório.", AllowEmptyStrings = false)]
        public string NomeCondominio { get; set; }

        [Column("IdResponsavel")]
        [Display(Name = "Responsável")]
        public int IdResponsavel { get; set; }

        private Adm administradora;

        public virtual Adm GetAdministradora()
        {
            return administradora;
        }

        public virtual void SetAdministradora(Adm value)
        {
            administradora = value;
        }

        private User responsavel;

        public virtual User GetResponsavel()
        {
            return responsavel;
        }

        public virtual void SetResponsavel(User value)
        {
            responsavel = value;
        }
    }
}