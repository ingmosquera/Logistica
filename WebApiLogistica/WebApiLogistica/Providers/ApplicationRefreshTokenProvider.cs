using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Configuration;

namespace WebApiLogistica.Providers
{
    public class ApplicationRefreshTokenProvider : AuthenticationTokenProvider
    {
        private int _tokenExpiration;
        public ApplicationRefreshTokenProvider()
        {
            _tokenExpiration = Convert.ToInt32(ConfigurationManager.AppSettings["TokenExpiration"]);
        }

        public override void Create(AuthenticationTokenCreateContext context)
        {
            // Expiration time in seconds
            int expire = _tokenExpiration;
            context.Ticket.Properties.ExpiresUtc = new DateTimeOffset(DateTime.Now.AddMinutes(expire));
            context.SetToken(context.SerializeTicket());
        }

        public override void Receive(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket(context.Token);
        }
    }
}