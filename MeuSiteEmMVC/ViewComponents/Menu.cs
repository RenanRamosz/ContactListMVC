using MeuSiteEmMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MeuSiteEmMVC.ViewComponents
{
    public class Menu : ViewComponent
    {
        public IViewComponentResult? Invoke()
        {
            string? sessaoUsuario = HttpContext?.Session.GetString("SessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario)) 
            {
                return Content("Usuario nao logado");
            }

            UsuarioModel? usuario = JsonSerializer.Deserialize<UsuarioModel>(sessaoUsuario);

            return View(usuario);
        }
    }
}
