namespace WebApiLogistica.Data.Repositorio.Entity
{
    public class ClienteEntity
    {
        public int Cliente_id { get; set; }
        public string cliente_razonsocial { get; set; }
        public string cliente_nit { get; set; }
        public string cliente_direccion { get; set; }
        public string cliente_telefono { get; set; }
        public int cliente_estado { get; set; }
        public string descEstado { get; set; }
        public string cliente_representantelegal { get; set; }
    }
}