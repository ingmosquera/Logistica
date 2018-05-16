using System;

namespace WebApiLogistica.Models
{
    public class UsuarioModel
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdEstado { get; set; }
        public string DescEstado { get; set; }
        public string Identificacion { get; set; }
        public DateTime FechaIngreso { get; set; }
        
    }
}