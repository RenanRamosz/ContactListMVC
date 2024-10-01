using MeuSiteEmMVC.Enums;
using MeuSiteEmMVC.Filters;
using MeuSiteEmMVC.Models;
using MeuSiteEmMVC.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeuSiteEmMVC.Controllers
{
    [PaginaParaUsuarioLogado]
    [PaginaSomenteAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IContatoRepository _contatoRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository, IContatoRepository contatoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _contatoRepository = contatoRepository;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> listarUsuarios = _usuarioRepository.BuscarTodos();
            return View(listarUsuarios);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepository.BuscarPorId(id);
            return View(usuario);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepository.BuscarPorId(id);
            return View(usuario);
        }

        public IActionResult ListarContatosPorUsuarioId(int id) 
        {
            List<ContatoModel> contatos = _contatoRepository.BuscarTodos(id);
            return PartialView("_ContatosUsuarios", contatos);
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepository.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso";
                    return RedirectToAction("Index");   
                }
                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Houve um erro ao cadastrar o usuario! Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Alterar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = new UsuarioModel();
                if (ModelState.IsValid)
                {
                    usuario.Id = usuarioSemSenhaModel.Id;
                    usuario.Nome = usuarioSemSenhaModel.Nome;
                    usuario.Login = usuarioSemSenhaModel.Login;
                    usuario.Email = usuarioSemSenhaModel.Email;
                    usuario.Perfil = usuarioSemSenhaModel.Perfil;

                    usuario = _usuarioRepository.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuario alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Houve um erro ao alterar o usuario! Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepository.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuario apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Falha ao apagar o usuario!";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Houve um erro ao apagar o usuario! Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
