using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_P_ORM_SQL.Modelos
{
    internal class Inter_Doc_Cita
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int CitaId { get; set; }
        public Cita Cita { get; set; }
    }
}
