using MeuSiteEmMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MeuSiteEmMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (loginModel.Login == "admin" && loginModel.Senha == "123")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["MensagemErro"] = "Login e/ou senha invalido(s)";
                }
                return View("Index");
            }
            catch (Exception message) 
            {
                TempData["MensagemErro"] = $"Houve um erro ao fazer login. Informações adicionais: {message}";
                return RedirectToAction("Index");
            }
        }
    }
}
