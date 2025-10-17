using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_P_ORM_SQL.Excepciones
{
    public class CitaNoDisponibleException : Exception
    {
        public CitaNoDisponibleException() : base("El horario seleccionado no está disponible.")
        {
        }

        public CitaNoDisponibleException(string message) : base(message)
        {
        }

        public CitaNoDisponibleException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
