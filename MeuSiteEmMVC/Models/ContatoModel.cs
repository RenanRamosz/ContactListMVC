using System.ComponentModel.DataAnnotations;

namespace MeuSiteEmMVC.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite email do contato")]
        [EmailAddress(ErrorMessage = "O email informado não é válido!")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite o telefone do contato")]
        [Phone(ErrorMessage = "O telefone informado não é válido!")]
        public string Telefone { get; set; } = string.Empty;
    }
}
