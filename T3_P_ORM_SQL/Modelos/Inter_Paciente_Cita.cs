using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_P_ORM_SQL.Modelos
{
    internal class Inter_Paciente_Cita
    {
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public int CitaId { get; set; }
        public Cita Cita { get; set; }
    }
}
