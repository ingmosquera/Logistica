using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;
using WebApiLogistica.Providers;

[assembly: OwinStartup(typeof(WebApiLogistica.Startup))]

namespace WebApiLogistica
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            ConfigureOAuth(app);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/v1/Autorizaciones"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new CredentialsAuthorizationServerProvider(),
                RefreshTokenProvider = new ApplicationRefreshTokenProvider()
            };
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            
            var authOptions = new OAuthBearerAuthenticationOptions()
            {
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active
            };
            app.UseOAuthBearerAuthentication(authOptions);
            
        }

       
    }
}
