using System;

namespace WebApiLogistica.Data.Repositorio.Entity
{

    public class UsuarioEntity
    {
        public string usuario_Id { get; set; }
        public string usuario_login { get; set; }
        public string usuario_contrasena { get; set; }
        public string usuario_nombres { get; set; }
        public string usuario_apellido { get; set; }
        public int usuario_estado { get; set; }
        public string usuario_descEstado { get; set; }
        public DateTime usuario_fechaCreacion { get; set; }
        public DateTime? usuario_ultfechaIngreso { get; set; }
        public string usuario_identificacion { get; set; }
    }
}