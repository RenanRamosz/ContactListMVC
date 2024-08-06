using MeuSiteEmMVC.Models;
using MeuSiteEmMVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MeuSiteEmMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;
        public ContatoController(IContatoRepository contatoRepository) 
        {
            _contatoRepository = contatoRepository;
        }
        public IActionResult Index()
        {
            List<ContatoModel> listarContatos = _contatoRepository.BuscarTodos();
            return View(listarContatos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepository.ListarPorId(id);
            return View(contato);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepository.ListarPorId(id);
            return View(contato);
        }
        [HttpPost]
        public IActionResult Criar(ContatoModel contato) 
        {
            _contatoRepository.Adicionar(contato);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            _contatoRepository.Atualizar(contato);
            return RedirectToAction("Index");
        }
        public IActionResult Apagar(int id)
        {
            _contatoRepository.Apagar(id);
            return RedirectToAction("Index");
        }

    }
}
