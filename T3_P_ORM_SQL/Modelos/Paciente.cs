using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_P_ORM_SQL.Modelos
{
    internal class Paciente
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }

        // La relación ahora es a través de la tabla intermedia PacienteCita
        public virtual ICollection<Inter_Paciente_Cita> PacienteCitas { get; set; }

        public Paciente() { }

        public Paciente(string nombre, string apellidop, string apellidom, int edad, string telefono)
        {
            Nombre = nombre;
            ApellidoP = apellidop;
            ApellidoM = apellidom;
            Telefono = telefono;
        }
    }
}
