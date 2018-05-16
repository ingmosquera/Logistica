using System;
using System.Web.Http;
using WebApiLogistica.Comun;

namespace WebApiLogistica
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //GlobalConfiguration.Configuration.MessageHandlers.Add(new ValidarToken());

            //Evito las referencias circulares al trabajar con Entity FrameWork         
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;

            //Elimino que el sistema devuelva en XML, sólo trabajaremos con JSON
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            MapperConfig.RegistrarMapping();

            /*
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
       .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            MapperConfig.RegistrarMapping();
            */
        }

        /*
        protected void Application_Error(Object sender, EventArgs e)
        {
            Exception exp = Server.GetLastError();
            CrearLog.RegistrarLog("Metodo:Error General en la aplicación", exp.ToString());
            Server.ClearError();
        }*/
        }
    }
