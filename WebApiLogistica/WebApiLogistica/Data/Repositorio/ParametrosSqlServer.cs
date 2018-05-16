using System.Data;
using System.Data.SqlClient;

namespace WebApiLogistica.Data.Repositorio
{
    public class ParametrosSqlServer
    {
        public static SqlParameter DevolverStringEntrada(string nombreCampo, string valor, int tamano)
        {
            var data = new SqlParameter(nombreCampo, SqlDbType.VarChar)
            {
                Value = valor,
                Size = tamano
            };
            return data;
        }

        public static SqlParameter DevolverStringSalida(string nombreCampo, int tamano)
        {
            var data = new SqlParameter(nombreCampo, SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Output,
                Size = tamano
            };
            return data;
        }

        public static SqlParameter DevolverIntEntrada(string nombreCampo, int valor)
        {
            var data = new SqlParameter(nombreCampo, SqlDbType.Int)
            {
                Value = valor

            };
            return data;
        }

        public static SqlParameter DevolverDecimal(string nombreCampo, decimal valor)
        {
            var data = new SqlParameter(nombreCampo, SqlDbType.Decimal)
            {
                Value = valor
            };
            return data;
        }

        public static SqlParameter DevolverDecimalEntrada(string nombreCampo, decimal valor)
        {
            var data = new SqlParameter(nombreCampo, SqlDbType.Decimal)
            {
                Value = valor
            };
            return data;
        }

        public static SqlParameter DevolverLongEntrada(string nombreCampo, long valor)
        {
            var data = new SqlParameter(nombreCampo, SqlDbType.BigInt)
            {
                Value = valor
            };
            return data;
        }
    }
}