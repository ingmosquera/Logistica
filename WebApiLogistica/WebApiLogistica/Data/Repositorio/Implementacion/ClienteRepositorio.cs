using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiLogistica.Comun;
using WebApiLogistica.Data.Repositorio.Entity;
using WebApiLogistica.Data.Repositorio.Interface;
using WebApiLogistica.Models;

namespace WebApiLogistica.Data.Repositorio.Implementacion
{
    public class ClienteRepositorio:Repositorio<ClienteEntity>,IClienteRepositorio
    {
        public List<ClienteModel> ListarTodo(string usuario) {

            var result = new List<ClienteModel>();
            result.Add(new ClienteModel()
            {
                id = 1,
                direccion = "Direccion 1",
                estado = 1,
                nit = "123456",
                razonsocial = "Tapirus it",
                representantelegal = "Alberto Mendoza",
                telefono = "123456",
                descEstado = "Activo"
            });
            return result;
            /*
            
            var paramUsuario = ParametrosSqlServer.DevolverStringEntrada("@USUARIO", usuario, 100);
            var dataEntity = Singleton.UnidadDeTrabajo.GetCliente().ExecStoreProcedure("dbo.spListarCliente @USUARIO", paramUsuario);
            if (dataEntity == null) {
                return null;
            }
            else {
                return dataEntity.Select(item => new ClienteModel()
                {
                    id = item.Cliente_id,
                    direccion = item.cliente_direccion,
                    estado = item.cliente_estado,
                    nit = item.cliente_nit,
                    razonsocial = item.cliente_razonsocial,
                    representantelegal = item.cliente_representantelegal,
                    telefono = item.cliente_telefono,
                    descEstado = item.descEstado
                }).ToList();
            }
            */
        }
    }
}