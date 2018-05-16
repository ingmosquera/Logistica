using WebApiLogistica.Data.Repositorio.Entity;
using WebApiLogistica.Data.Repositorio.Interface;
using WebApiLogistica.Models;

namespace WebApiLogistica.Data.Repositorio.Implementacion
{
    public class LoginRepositorio:Repositorio<UsuarioEntity>,ILoginRepositorio
    {
        

        public LoginRepositorio()
        {
        }
        
        public UsuarioLogin DatosUsuario(string usuario, string contrasena)
        {
            var paramLogin = ParametrosSqlServer.DevolverStringEntrada("@Login", usuario, 100);
            var paramContrasena = ParametrosSqlServer.DevolverStringEntrada("@Password", contrasena, 250);
            /*
            var dataEntity = Singleton.UnidadDeTrabajo.GetLogin().ExecStoreProcedureReturnOneParameter("dbo.spValidoLogin @Login,@Password", paramLogin, paramContrasena);
            if (dataEntity == null) {
                return null;
            }
            else
            {
                var data = new UsuarioLogin()
                {
                    Id = dataEntity.usuario_Id,
                    Apellido = dataEntity.usuario_apellido,
                    Login = dataEntity.usuario_login,
                    Nombre = dataEntity.usuario_nombres,
                    token = CrearToken.GenerarToken(),
                    IdEstado = dataEntity.usuario_estado
                };
                return data;
            }
             */

            var data = new UsuarioLogin()
            {
                Id = "NUEVOUSUARIODELOGIN",
                Apellido = "ADMIN",
                Login = "ADMIN",
                Nombre = "ADMIN",
                IdEstado = 1
            };
            return data;

        }
    }
}