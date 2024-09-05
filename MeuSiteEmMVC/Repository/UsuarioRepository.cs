using MeuSiteEmMVC.Data;
using MeuSiteEmMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuSiteEmMVC.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepository( BancoContext bancoContext) 
        {
            _bancoContext = bancoContext;
        }
        public UsuarioModel? BuscarPorLogin(string login)
        {
            var loginEncontrado = _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
            return loginEncontrado;
        }
        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }
        public UsuarioModel BuscarPorId(int id)
        {
            var usuario = _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
            if (usuario == null) 
            {
                throw new InvalidOperationException("Usuario não encontrado.");
            }
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = BuscarPorId(usuario.Id);
            if (usuarioDb == null) throw new InvalidOperationException("Erro ao atualizar o usuario.");

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Perfil = usuario.Perfil;
            usuarioDb.DataAtualizacao = DateTime.Now;

            _bancoContext.Usuarios.Update(usuarioDb);
            _bancoContext.SaveChanges();
            return usuarioDb;
        }
        public bool Apagar(int id)
        {
            UsuarioModel usuarioDb = BuscarPorId(id);
            if (usuarioDb == null) throw new SystemException("Erro ao deletar o usuario");

            _bancoContext.Usuarios.Remove(usuarioDb);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
