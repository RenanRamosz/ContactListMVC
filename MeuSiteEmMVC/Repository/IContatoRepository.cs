using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Repository
{
    public interface IContatoRepository
    {
        List<ContatoModel> BuscarTodos(int UsuarioId);
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel BuscarPorId(int id);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);
    }
}
    