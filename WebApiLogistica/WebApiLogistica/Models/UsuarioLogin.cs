namespace WebApiLogistica.Models
{
    public class UsuarioLogin
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdEstado { get; set; }
    }
}