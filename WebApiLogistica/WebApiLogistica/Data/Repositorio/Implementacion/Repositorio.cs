using System;
using System.Collections.Generic;
using System.Linq;
using WebApiLogistica.Comun;
using WebApiLogistica.Data.Repositorio.Interface;

namespace WebApiLogistica.Data.Repositorio.Implementacion
{
    public class Repositorio<T>: IRepositorio<T> where T:class
     {
        private readonly DbContextLogistica _Context = new DbContextLogistica();
        private const string EJECUTA = "EXEC ";
        public string InsertModel(string sql, params object[] param)
        {
            string mensaje = string.Empty;
            try
            {
                //mensaje = _Context.Database.ExecuteSqlCommand(EJECUTA + sql, param).ToString();
                var resultado = _Context.Database.SqlQuery<decimal>(EJECUTA + sql, param).FirstOrDefault();
                if (resultado>=1)
                {
                    mensaje = "Proceso de creación exitoso";
                }
                else
                {
                    mensaje = "Creación no exitosa. Favor revisar los parametros";
                }
            }
            catch (Exception ex)
            {
                CrearLog.RegistrarLog("Procedure :" + sql, ex.ToString());
                if (ex.ToString().Contains("PRIMARY"))
                {
                    mensaje = "El usuario que esta ingreando ya existe";
                }
                else
                {
                    mensaje = "Error al realizar la creación del usuario en la BD ";
                }
            }

            return mensaje;
        }


        public List<T> ExecStoreProcedure(string sql, params object[] param) {
            try
            {
                return _Context.Database.SqlQuery<T>(EJECUTA + sql, param).ToList();
            }
            catch (Exception ex)
            {
                CrearLog.RegistrarLog("Procedure :" + sql, ex.ToString());
                throw ex;
            }
        }


        public T ExecStoreProcedureReturnOneParameter(string sql, params object[] param)
        {
            try
            {
                return _Context.Database.SqlQuery<T>(EJECUTA + sql, param).FirstOrDefault();
            }
            catch (Exception ex)
            {
                CrearLog.RegistrarLog("Procedure :" + sql, ex.ToString());
                throw ex;
            }
        }

        public string UpdateModel(string sql, params object[] param)
        {
            string mensaje = string.Empty;
            try
            {
                var resultado = _Context.Database.SqlQuery<decimal>(EJECUTA + sql, param).FirstOrDefault();
                if (resultado >=1)
                {
                    mensaje = "Actualización realizada con éxito";
                }
                else
                {
                    mensaje = "Actualización no exitosa. Favor revisar los parametros";
                }
            }
            catch (Exception ex)
            {
                CrearLog.RegistrarLog("Procedure :" + sql, ex.ToString());
                mensaje = "Error al realiar la actualización en la BD";
            }
            return mensaje;
        }
    }
}

/*
public DbRawSqlQuery<T> SelectModelWithParameters(string sql, params object[] param)
{
    try
    {
        return _Context.Database.SqlQuery<T>(EJECUTA + sql, param);
    }
    catch (Exception ex)
    {
        CrearLog.RegistrarLog("Procedure :" + sql, ex.ToString());
        throw ex;
    }

}

public DbRawSqlQuery<T> SelectModel(string sql)
{
    try
    {
        return _Context.Database.SqlQuery<T>(EJECUTA + sql);
    }
    catch (Exception ex)
    {
        CrearLog.RegistrarLog("Procedure :" + sql, ex.ToString());
        throw ex;
    }

}
*/
