using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Repository
{
    public interface IUsuarioRepository
    {
        UsuarioModel? BuscarPorLogin(string login);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel BuscarPorId(int id);
        UsuarioModel Atualizar(UsuarioModel usuario);
        bool Apagar(int id);
    }
}
