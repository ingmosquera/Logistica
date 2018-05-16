using System.Collections.Generic;
using WebApiLogistica.Data.Repositorio.Entity;
using WebApiLogistica.Models;

namespace WebApiLogistica.Data.Repositorio.Interface
{
    public interface IClienteRepositorio:IRepositorio<ClienteEntity>
    {
        List<ClienteModel> ListarTodo(string usuario);
    }
}
