using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiLogistica.Controllers
{

    public class LogoutController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Salir() {
            //Request.GetOwinContext().Authentication.SignOut(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ApplicationCookie);
            //HttpContext.Current.GetOwinContext().Authentication.SignOut(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ApplicationCookie);
            Request.GetOwinContext().Authentication.SignOut();
            return Request.CreateResponse(HttpStatusCode.OK, "Ha salido del aplicación");
        }
    }
}
