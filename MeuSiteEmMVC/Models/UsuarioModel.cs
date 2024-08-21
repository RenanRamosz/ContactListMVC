using MeuSiteEmMVC.Enums;

namespace MeuSiteEmMVC.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public PerfilEnum Perfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
