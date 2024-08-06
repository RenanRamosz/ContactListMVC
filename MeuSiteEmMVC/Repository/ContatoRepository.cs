using MeuSiteEmMVC.Data;
using MeuSiteEmMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;


namespace MeuSiteEmMVC.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }
        public ContatoModel ListarPorId(int id)
        {
            var contato = _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
            if (contato == null)
            {
                throw new InvalidOperationException("Contato não encontrado.");
            }
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDb = ListarPorId(contato.Id);
            if (contatoDb == null) throw new InvalidOperationException("Erro ao atualizar o contato");

            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Telefone = contato.Telefone;
            _bancoContext.Contatos.Update(contatoDb);
            _bancoContext.SaveChanges();
            return contatoDb;

        }
        public bool Apagar(int id)
        {
            ContatoModel contatoDb = ListarPorId(id);
            if (contatoDb == null) throw new SystemException("Erro ao deletar o contato");

            _bancoContext.Contatos.Remove(contatoDb);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
