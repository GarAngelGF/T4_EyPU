using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_P_ORM_SQL.Modelos
{
    internal class Cita
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Motivo { get; set; }

        // Relaciones a las tablas intermedias
        public virtual ICollection<Inter_Doc_Cita> DoctorCitas { get; set; }
        public virtual ICollection<Inter_Paciente_Cita> PacienteCitas { get; set; }

        // Propiedades no mapeadas (se necesitaría lógica adicional para llenarlas)
        [NotMapped]
        public string Hora => FechaHora.ToString("HH:mm");
        [NotMapped]
        public string NombreMedico { get; set; } // Esta propiedad ahora se llenaría manualmente
        [NotMapped]
        public string NombrePaciente { get; set; } // Esta propiedad ahora se llenaría manualmente

        public Cita() { }

        public Cita(DateTime fechaHora, string motivo)
        {
            FechaHora = fechaHora;
            Motivo = motivo;
        }
    }
}
