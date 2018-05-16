using WebApiLogistica.Data.Modelo;
using WebApiLogistica.Data.Repositorio;

namespace WebApiLogistica.Comun
{
    public class Singleton
    {
        public static LogisticaEntities logistica = null;
        public static UnidadTrabajo unidad = null;

        private static readonly object padlock = new object();

        private Singleton()
        {

        }

        public static UnidadTrabajo UnidadDeTrabajo
        {
            get
            {

                lock (padlock)
                {
                    if (unidad == null)
                    {
                        unidad = new UnidadTrabajo();
                    }
                    return unidad;
                }
            }
        }
    }
}