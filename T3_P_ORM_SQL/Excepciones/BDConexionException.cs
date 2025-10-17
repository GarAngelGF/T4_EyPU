using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_P_ORM_SQL.Excepciones
{
    public class BDConexionException : Exception
    {
        public BDConexionException() : base("Ocurrió un error al intentar conectar a la base de datos.")
        {
        }

        public BDConexionException(string message) : base(message)
        {
        }

        public BDConexionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
