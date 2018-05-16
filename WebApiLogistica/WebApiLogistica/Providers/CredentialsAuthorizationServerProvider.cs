using Microsoft.Owin.Security.OAuth;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApiLogistica.Comun;
using WebApiLogistica.Models;

namespace WebApiLogistica.Providers
{
    public class CredentialsAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private UsuarioLogin dataUsuario = new UsuarioLogin();

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            dataUsuario = Singleton.UnidadDeTrabajo.GetLogin().DatosUsuario(context.UserName, context.Password);
            if (dataUsuario == null)
            {
                context.SetError("invalid_grant", "Usuario y contraseña inválida");
                return;
            }
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, dataUsuario.Id));
            identity.AddClaim(new Claim(ClaimTypes.Role, ""));
            //identity.AddClaim(new Claim("creationDate", Convert.ToString(TimeSpan.FromDays(1))));
          //  identity.AddClaim(new Claim("UserEstado", Convert.ToString(dataUsuario.IdEstado)));
            context.Validated(identity);
        }

        public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            context.AdditionalResponseParameters.Add("userName", dataUsuario.Nombre+" "+ dataUsuario.Apellido);
            context.AdditionalResponseParameters.Add("userId", dataUsuario.Id);
            context.AdditionalResponseParameters.Add("userState", Convert.ToString(dataUsuario.IdEstado));
            return base.TokenEndpointResponse(context);
        }
    }

}