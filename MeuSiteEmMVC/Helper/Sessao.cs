using MeuSiteEmMVC.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace MeuSiteEmMVC.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public Sessao(IHttpContextAccessor contextAccessor) 
        {
            _contextAccessor = contextAccessor;
        }
        public UsuarioModel? BuscarSessaoUsuario()
        {
            string? sessaoUsuario = _contextAccessor.HttpContext?.Session.GetString("SessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                return null;
            }
            return JsonSerializer.Deserialize<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessaoUsuario(UsuarioModel usuario)
        {
            string valor = JsonSerializer.Serialize(usuario);
            _contextAccessor.HttpContext?.Session.SetString("SessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoUsuario()
        {
            _contextAccessor.HttpContext?.Session.Clear();
        }
    }
}
