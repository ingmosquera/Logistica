using AutoMapper;
using System.Data.Entity;
using WebApiLogistica.Data.Repositorio.Implementacion;
using WebApiLogistica.Data.Repositorio.Interface;

namespace WebApiLogistica.Data.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private DbContextLogistica _context;
        //private IMapper imapper;
        /*
        public UnidadTrabajo(DbContext context)
        {
            context = _context;
        }
        */
        public void Dispose()
        {
            _context.Dispose();
        }

        public IClienteRepositorio GetCliente()
        {
            return new ClienteRepositorio();
        }

        public ILoginRepositorio GetLogin()
        {
            return new LoginRepositorio();
        }
    }
}