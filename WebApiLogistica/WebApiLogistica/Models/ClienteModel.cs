namespace WebApiLogistica.Models
{
    public class ClienteModel
    {
        public int id { get; set; }
        public string razonsocial { get; set; }
        public string nit { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public int estado { get; set; }
        public string descEstado { get; set; }
        public string representantelegal { get; set; }
    }
}