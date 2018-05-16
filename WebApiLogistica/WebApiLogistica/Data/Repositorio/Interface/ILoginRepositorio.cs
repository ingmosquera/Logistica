using WebApiLogistica.Data.Repositorio.Entity;
using WebApiLogistica.Models;

namespace WebApiLogistica.Data.Repositorio.Interface
{
    public interface ILoginRepositorio:IRepositorio<UsuarioEntity>
    {
        UsuarioLogin DatosUsuario(string usuario, string contrasena);
    }
}
