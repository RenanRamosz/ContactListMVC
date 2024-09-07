using MeuSiteEmMVC.Helper;
using MeuSiteEmMVC.Models;
using MeuSiteEmMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MeuSiteEmMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepository usuarioRepository, ISessao sessao) 
        {
            _usuarioRepository = usuarioRepository;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
           UsuarioModel? usuarioLogado = _sessao.BuscarSessaoUsuario();
            if (usuarioLogado != null) 
            {
               return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    UsuarioModel? usuario = _usuarioRepository.BuscarPorLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.ValidarSenha(loginModel.Senha))
                        {
                            _sessao.CriarSessaoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = "Senha invalida. Por favor tente novamente.";
                    }

                    else
                    {
                        TempData["MensagemErro"] = "Login e/ou senha invalido(s)";
                    }

                }

                return View("Index");
            }
            catch (Exception message) 
            {
                TempData["MensagemErro"] = $"Houve um erro ao fazer login. Informações adicionais: {message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Sair() 
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index");
        }
    }
}
