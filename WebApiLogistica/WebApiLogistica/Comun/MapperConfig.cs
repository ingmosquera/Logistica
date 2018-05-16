using AutoMapper;
using WebApiLogistica.Data.Repositorio.Entity;
using WebApiLogistica.Models;

namespace WebApiLogistica.Comun
{
    public class MapperConfig:Profile
    {
        public static void RegistrarMapping() {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<UsuarioModel, UsuarioEntity>();
            });
        }
    }
}