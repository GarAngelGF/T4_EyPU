using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_P_ORM_SQL.Excepciones
{
    public class DatosInvalidosException : Exception
    {
        public DatosInvalidosException() : base("Datos inválidos.")
        {
        }

        public DatosInvalidosException(string message) : base(message)
        {
        }

        public DatosInvalidosException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
