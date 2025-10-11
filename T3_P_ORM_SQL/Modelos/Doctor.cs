using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_P_ORM_SQL.Modelos
{
    internal class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string Rfc { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Telefono { get; set; }
        public string Especialidad { get; set; }
        public string NumeroLicencia { get; set; }

        // La relación ahora es a través de la tabla intermedia DoctorCita
        public virtual ICollection<Inter_Doc_Cita> DoctorCitas { get; set; }

        [NotMapped]
        public string DisplayText => string.IsNullOrWhiteSpace(Especialidad) || Especialidad == "Médico General"  ? Nombre : $"{Nombre} - {Especialidad}";

        public override string ToString() => this.DisplayText;

        public Doctor() { }

        public Doctor(string rfc, string nombre, string apellidop, string apellidom, string telefono, string especialidad, string numeroLicencia)
        {
            this.Rfc = rfc;
            this.Nombre = nombre;
            this.ApellidoP = apellidop;
            this.ApellidoM = apellidom;
            this.Telefono = telefono;
            this.Especialidad = especialidad;
            this.NumeroLicencia = numeroLicencia;
        }
    }
}
