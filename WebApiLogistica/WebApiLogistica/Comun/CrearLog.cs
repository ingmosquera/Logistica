using System;
using System.IO;
using System.Web;

namespace WebApiLogistica.Comun
{
    public class CrearLog
    {
        private static string RutaLog()
        {
            DateTime Hoy = DateTime.Today;
            string log = "APIlog" + Hoy.ToString("dd-MM-yyyy") + ".txt";
            return Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data/"), log);
        }

        private static string DevolverFechaHora()
        {
            return DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
        }

        public static void RegistrarLog(string actividad, string cadena)
        {
            var path = RutaLog();
            var Info = DevolverFechaHora() + "- " + actividad + " : " + cadena;
            if (File.Exists(path))
            {
                StreamWriter mylogs = new StreamWriter(path, true);
                mylogs.WriteLine(Info);
                mylogs.Close();
            }
            else
            {
                StreamWriter mylogs = File.AppendText(path);
                mylogs.WriteLine(Info);
                mylogs.Close();
            }
        }
    }
}