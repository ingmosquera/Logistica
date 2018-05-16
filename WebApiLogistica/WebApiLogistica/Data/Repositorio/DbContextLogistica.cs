using System.Data.Entity;
using WebApiLogistica.Data.Repositorio.Entity;

namespace WebApiLogistica.Data.Repositorio
{
    public class DbContextLogistica : DbContext
    {
        public DbContextLogistica() : base("name = LogisticaEntities")
        {

        }

        public DbSet<UsuarioEntity> UsuarioLogin {get; private set;}
        public DbSet<ClienteEntity> clienteentity { get; private set; }
    }
}