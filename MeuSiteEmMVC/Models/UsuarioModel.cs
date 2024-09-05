using MeuSiteEmMVC.Enums;
using System.ComponentModel.DataAnnotations;

namespace MeuSiteEmMVC.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuario")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite o login do usuario")]
        public string Login { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite a senha do usuario")]
        public string Senha { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite o email do usuario")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Informe o perfil do usuario")]
        public PerfilEnum? Perfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool ValidarSenha(string senha) 
        {
            return senha == Senha;
        }
    }
}
