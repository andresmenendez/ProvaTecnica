using Prova.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Prova.Models
{
    [Table("tbUser")]
    public class User
    {
        [Key]
        [Column("IdUser")]
        public int IdUser { get; set; }

        [Column("Name")]
        [Display(Name = "Nome Usuário")]
        [Required(ErrorMessage = "O nome do usuário é obrigatório.", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Column("Email")]
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O e-mail é obrigatório.", AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }


        [Column("IdCondominio")]
        [Display(Name = "Condomínio")]
        public int IdCondominio { get; set; }

        [Column("TipoUser")]
        [Display(Name = "Tipo do Usuário")]
        public int TipoUser { get; set; }

        private Condominio condominio;

        public virtual Condominio GetCondominio()
        {
            return condominio;
        }

        public virtual void SetCondominio(Condominio value)
        {
            condominio = value;
        }

        public string TipoUsuarioString(int TipoUser)
        {
            switch (TipoUser)
            {
                case 1: return "Morador";
                case 2: return "Síndico";
                case 3: return "Administradora";
                case 4: return "Zelador";
                default:
                    return "";
            }
        }
    }
}