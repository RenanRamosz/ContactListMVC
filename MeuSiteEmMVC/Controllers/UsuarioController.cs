using Microsoft.AspNetCore.Mvc;

namespace MeuSiteEmMVC.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index() 
        { 
            return View(); 
        }

        public IActionResult Criar()
        {
            return Criar();
        }
    }
}
