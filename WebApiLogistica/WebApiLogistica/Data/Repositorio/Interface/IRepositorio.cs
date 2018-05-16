using System.Collections.Generic;

namespace WebApiLogistica.Data.Repositorio.Interface
{
    public interface IRepositorio<T> where T:class
    {
        //DbRawSqlQuery<T> SelectModel(string sql);
        //DbRawSqlQuery<T> SelectModelWithParameters(string sql, params object[] param);
        string InsertModel(string sql, params object[] param);
        string UpdateModel(string sql, params object[] param);
        List<T> ExecStoreProcedure(string sql, params object[] param);
        T ExecStoreProcedureReturnOneParameter(string sql, params object[] param);
    }
}
