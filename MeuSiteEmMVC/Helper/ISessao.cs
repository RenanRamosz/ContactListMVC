using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Helper
{
    public interface ISessao
    {
        void CriarSessaoUsuario(UsuarioModel usuario);
        void RemoverSessaoUsuario();
        UsuarioModel? BuscarSessaoUsuario();
    }
}
