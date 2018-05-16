using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiLogistica
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            //var enableCorsAttribute = new EnableCorsAttribute("*","Origin, Content-Type, Accept","GET, PUT, POST, DELETE, OPTIONS");
            //config.EnableCors(enableCorsAttribute);
            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //Evito las referencias circulares al trabajar con Entity FrameWork         
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;

            //Elimino que el sistema devuelva en XML, sólo trabajaremos con JSON
            config.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            /*
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.UseDataContractJsonSerializer = true;
            */
        }
    }
}
