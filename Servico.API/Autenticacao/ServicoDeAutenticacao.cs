using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Infraestrutura.Autenticacao
{
    public class ServicoDeAutenticacao : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public ServicoDeAutenticacao(
            IOptionsMonitor<AuthenticationSchemeOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder, 
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            const int primeirosSeisCaracteres = 6;
            const char caracterDividor = ':';
            const string usernameAutorizado = "admin";
            const string passwordAutorizado = "1234";

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }
             
            string autorizacaoDoHeader = Request.Headers["Authorization"];

            if(string.IsNullOrEmpty(autorizacaoDoHeader))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            if(!autorizacaoDoHeader.StartsWith("basic ", StringComparison.OrdinalIgnoreCase))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            var token = autorizacaoDoHeader.Substring(primeirosSeisCaracteres);
            var credenciaisComoString = Encoding.UTF8.GetString(Convert.FromBase64String(token));

            var credenciais =credenciaisComoString.Split(caracterDividor);

            if(credenciais?.Length != 2)
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            var username = credenciais[0];
            var password = credenciais[1];

            if(username != usernameAutorizado || password != passwordAutorizado)
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            var claims = new[] { new Claim(ClaimTypes.NameIdentifier, username) };
            var identity = new ClaimsIdentity(claims, "Basic");
            var claimsPrincipal = new ClaimsPrincipal(identity);
            return AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name));
        }
    }
}
