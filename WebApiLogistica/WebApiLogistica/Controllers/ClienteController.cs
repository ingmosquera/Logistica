using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiLogistica.Comun;

namespace WebApiLogistica.Controllers
{
    [Authorize]
    public class ClienteController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage ListarClientes(string id) {
            try
            {
                if (id != null)
                {
                    var result = Singleton.UnidadDeTrabajo.GetCliente().ListarTodo(id);
                        return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Se debe diligenciar el usuario y la contraseña"));
                }
            }
            catch (Exception ex)
            {
                CrearLog.RegistrarLog("Metodo:ListarTodosClientes", ex.ToString());
                return Request.CreateResponse(HttpStatusCode.Forbidden, "Error al listar todos los clientes");
            }
        }

    }
}
