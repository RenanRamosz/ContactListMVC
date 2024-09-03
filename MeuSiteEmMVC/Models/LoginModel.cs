using System.ComponentModel.DataAnnotations;

namespace MeuSiteEmMVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o login do usuario")]
        public string Login { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite a senha do usuario")]
        public string Senha { get; set; } = string.Empty;
    }
}
