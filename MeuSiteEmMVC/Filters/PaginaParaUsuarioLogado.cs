using MeuSiteEmMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace MeuSiteEmMVC.Filters
{
    public class PaginaParaUsuarioLogado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string? usuarioLogado = context.HttpContext.Session.GetString("SessaoUsuarioLogado");
            if (string.IsNullOrEmpty(usuarioLogado))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "login" }, { "action", "index" } });
            }
            else 
            {
                UsuarioModel? usuario = JsonSerializer.Deserialize<UsuarioModel>(usuarioLogado);
                if (usuario == null) 
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "login" }, { "action", "index" } });
                }
            }
            base.OnActionExecuting(context);
        }
    }
}
