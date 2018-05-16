using System;
using WebApiLogistica.Data.Repositorio.Interface;

namespace WebApiLogistica.Data.Repositorio
{
    public interface IUnidadTrabajo:IDisposable
    {
        IClienteRepositorio GetCliente();
        ILoginRepositorio GetLogin();
    }
}
