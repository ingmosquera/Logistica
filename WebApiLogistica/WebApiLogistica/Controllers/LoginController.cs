using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiLogistica.Comun;
using WebApiLogistica.Models;

namespace WebApiLogistica.Controllers
{
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        [HttpPost]
        public async Task<HttpResponseMessage> Autorizacion(LoginModel login) {
            try
            {
                if (login != null)
                {
                    var result = Singleton.UnidadDeTrabajo.GetLogin().DatosUsuario(login.Login, login.Contrasena);
                    if (result== null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Usuario y contraseña inválida"));
                    }
                    else {
                        var testServer = TestServer.Create<Startup>();
                        var requestParams = new List<KeyValuePair<string, string>>
                                            {
                                                new KeyValuePair<string, string>("grant_type", "password"),
                                                new KeyValuePair<string, string>("username",login.Login),
                                                new KeyValuePair<string, string>("password", login.Contrasena)
                                            };
                        var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
                        var tokenServiceResponse = await testServer.HttpClient.PostAsync(
                            "/v1/Autori", requestParamsFormUrlEncoded);
                        
                        //var data1 = ActionContext.Request.Headers.Authorization.Parameter;
                        return Request.CreateResponse(HttpStatusCode.OK, tokenServiceResponse);
                    }
                }
                else {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Se debe diligenciar el usuario y la contraseña"));
                }
            }
            catch (Exception ex)
            {
                CrearLog.RegistrarLog("Metodo:Autorizacion", ex.ToString());
                return Request.CreateResponse(HttpStatusCode.Forbidden, "Error al procesar la solicitud de Autorización");
            }
        }
    }
}
