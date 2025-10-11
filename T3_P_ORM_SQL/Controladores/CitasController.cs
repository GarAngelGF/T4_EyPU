using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using T3_P_ORM_SQL.Modelos;
using T3_P_ORM_SQL.Vistas.Citas_Crud;

namespace T3_P_ORM_SQL.Controladores
{
    // Controlador genérico para manejar la lógica de negocio de las Citas (CRUD).
    // Gestiona la interacción entre las vistas y el modelo de datos.
    internal class CitasController<Tform> where Tform : Form
    {
        private readonly Tform _form;
        private readonly BindingSource vercitasBindinSource;
        private readonly BindingSource verdoctoresBindinSource;
        private readonly BindingSource verpacientesBindinSource;
        private readonly BindingSource verhorarioBindinSource;
        private readonly Contextobd contextobd;

        // Inicializa una nueva instancia del controlador de citas.
        public CitasController(Tform tform, Contextobd contextobd)
        {
            this.contextobd = contextobd;
            this._form = tform;
            this.vercitasBindinSource = new BindingSource();
            this.verdoctoresBindinSource = new BindingSource();
            this.verpacientesBindinSource = new BindingSource();
            this.verhorarioBindinSource = new BindingSource();
        }

        // Obtiene y formatea todas las citas para mostrarlas en una vista (ej. DataGridView).
        public BindingSource OnVerCitas()
        {
            var Citas = contextobd.Citas
                // Incluye los datos relacionados de DoctorCitas y luego los del Doctor.
                // Esto se llama "Eager Loading" y evita múltiples consultas a la base de datos.
                .Include(c => c.DoctorCitas)
                    .ThenInclude(dc => dc.Doctor)
                // Proyecta el resultado en un nuevo objeto anónimo. Esto es útil para
                // dar forma a los datos exactamente como los necesita la vista.
                .Select(c => new
                {
                    IdDeLaCita = c.Id,
                    IdDelPaciente = c.PacienteCitas.Select(pc => pc.Paciente.Id).FirstOrDefault(),
                    IdDelMedico = c.DoctorCitas.Select(pc => pc.Doctor.Id).FirstOrDefault(),
                    Fecha = c.FechaHora,
                    MotivoCita = c.Motivo,
                    NombreDelDoctor = c.DoctorCitas.Select(dc => dc.Doctor.Nombre).FirstOrDefault(),
                    NombreDelPaciente = c.PacienteCitas.Select(pc => pc.Paciente.Nombre).FirstOrDefault()
                })
                .ToList();
            vercitasBindinSource.DataSource = Citas;
            return vercitasBindinSource;
        }

        // Carga la lista de todos los doctores en un BindingSource.
        public BindingSource OnCargarDoctor()
        {
            var Doctor = contextobd.Doctores.ToList();
            verdoctoresBindinSource.DataSource = Doctor;
            return verdoctoresBindinSource;
        }

        // Carga la lista de todos los pacientes en un BindingSource.
        public BindingSource ONCargarPaciente()
        {
            var pacientes = contextobd.Pacientes.ToList();
            verpacientesBindinSource.DataSource = pacientes;
            return verpacientesBindinSource;
        }

        // Genera una lista de horarios disponibles (de 9:00 a 18:30 en intervalos de 30 min).
        public BindingSource OnCargarHorario()
        {
            var horariosDisponibles = new List<string>();
            for (int hora = 9; hora < 19; hora++)
            {
                horariosDisponibles.Add($"{hora:00}:00");
                horariosDisponibles.Add($"{hora:00}:30");
            }
            verhorarioBindinSource.DataSource = horariosDisponibles;
            return verhorarioBindinSource;
        }

        // Valida si un doctor ya tiene una cita agendada en una fecha y hora específicas.
        public bool OnValidarConflicto(Doctor doctor, DateTime Fechayhoraseleccionada)
        {
            int idDelDoctor = doctor.Id;
            // .Any() es muy eficiente. Se traduce a una consulta SQL EXISTS, que solo
            // comprueba si existe al menos un registro que cumpla la condición, sin traer los datos.
            bool HayConflicto = contextobd.Citas.Include(dc => dc.DoctorCitas).Any(c => c.FechaHora == Fechayhoraseleccionada && c.DoctorCitas.Any(dc => dc.DoctorId == idDelDoctor));
            return HayConflicto;
        }

        // Valida si un paciente ya tiene una cita agendada en una fecha y hora específicas.
        public bool OnNoCitaPrevia(Paciente paciente, DateTime Fechayhoraseleccionada)
        {
            int idDelPaciente = paciente.Id;
            bool HayConflicto = contextobd.Citas
                .Include(dc => dc.PacienteCitas)
                .Any(c => c.FechaHora == Fechayhoraseleccionada &&
                          c.PacienteCitas.Any(dc => dc.PacienteId == idDelPaciente));
            return HayConflicto;
        }

        // Agenda una nueva cita después de validar que no existan conflictos de horario.
        public void OnAgendarCitas(Doctor doctor, Paciente paciente, DateTime Fechayhoraseleccionada, string motivo)
        {
            if (OnValidarConflicto(doctor, Fechayhoraseleccionada))
            {
                MessageBox.Show($"El Dr. {doctor.Nombre} ya tiene una cita programada en esa fecha y hora.", "Conflicto de Horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (OnNoCitaPrevia(paciente, Fechayhoraseleccionada))
            {
                MessageBox.Show($"El paciente {paciente.Nombre} ya tiene una cita programada en esa fecha y hora.", "Conflicto de Horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Al crear una nueva Cita y añadirle las entidades relacionadas (Doctor y Paciente)
            // a sus colecciones, Entity Framework es lo suficientemente inteligente para
            // crear la Cita y, al mismo tiempo, los registros correspondientes en las
            // tablas intermedias (Inter_Doc_Cita e Inter_Paciente_Cita).
            var nuevaCita = new Cita
            {
                FechaHora = Fechayhoraseleccionada,
                Motivo = motivo,
                DoctorCitas = new List<Inter_Doc_Cita> { new Inter_Doc_Cita { Doctor = doctor } },
                PacienteCitas = new List<Inter_Paciente_Cita> { new Inter_Paciente_Cita { Paciente = paciente } }
            };

            contextobd.Citas.Add(nuevaCita);
            contextobd.SaveChanges();
            MessageBox.Show("Cita agendada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Modifica una cita existente.
        public void OnModificar(int citaId, int nuevoDoctorId, int nuevoPacienteId, DateTime nuevaFechaHora, string nuevoMotivo)
        {
            // Es crucial primero obtener la entidad original de la base de datos.
            // EF la "rastreará" para detectar cualquier cambio.
            var citaOriginal = contextobd.Citas.FirstOrDefault(c => c.Id == citaId);
            if (citaOriginal == null)
            {
                MessageBox.Show("Error: La cita que intenta modificar no fue encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Se modifican las propiedades directas de la cita.
            citaOriginal.FechaHora = nuevaFechaHora;
            citaOriginal.Motivo = nuevoMotivo;

            // --- Lógica compleja para cambiar la relación (Doctor/Paciente) ---
            // No podemos simplemente cambiar el ID en la tabla intermedia porque
            // DoctorId y PacienteId son parte de su clave primaria. Una clave primaria
            // no se puede modificar. La solución es: 1. Eliminar la relación vieja. 2. Crear una nueva.
            var relacionDoctorActual = contextobd.DoctorCitas.FirstOrDefault(dc => dc.CitaId == citaId);
            if (relacionDoctorActual != null && relacionDoctorActual.DoctorId != nuevoDoctorId)
            {
                contextobd.DoctorCitas.Remove(relacionDoctorActual);
                var nuevaRelacionDoctor = new Inter_Doc_Cita { CitaId = citaId, DoctorId = nuevoDoctorId };
                contextobd.DoctorCitas.Add(nuevaRelacionDoctor);
            }

            var relacionPacienteActual = contextobd.PacienteCitas.FirstOrDefault(pc => pc.CitaId == citaId);
            if (relacionPacienteActual != null && relacionPacienteActual.PacienteId != nuevoPacienteId)
            {
                contextobd.PacienteCitas.Remove(relacionPacienteActual);
                var nuevaRelacionPaciente = new Inter_Paciente_Cita { CitaId = citaId, PacienteId = nuevoPacienteId };
                contextobd.PacienteCitas.Add(nuevaRelacionPaciente);
            }

            try
            {
                // Guarda todos los cambios (la modificación de la cita, la eliminación
                // y la creación de relaciones) en una sola transacción.
                contextobd.SaveChanges();
                MessageBox.Show("Cita actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar los cambios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Elimina una cita y sus relaciones correspondientes.
        public void OnEliminar(int citaId)
        {
            var citaParaEliminar = contextobd.Citas.FirstOrDefault(c => c.Id == citaId);

            // Es fundamental eliminar primero los registros de las tablas dependientes
            // (las tablas intermedias) antes de eliminar el registro principal (la cita).
            // Si no se hace en este orden, la base de datos arrojará un error de
            // restricción de clave foránea (foreign key constraint).
            var relacionesDoctor = contextobd.DoctorCitas.Where(dc => dc.CitaId == citaId);
            var relacionesPaciente = contextobd.PacienteCitas.Where(pc => pc.CitaId == citaId);

            if (relacionesDoctor.Any())
            {
                contextobd.DoctorCitas.RemoveRange(relacionesDoctor);
            }

            if (relacionesPaciente.Any())
            {
                contextobd.PacienteCitas.RemoveRange(relacionesPaciente);
            }

            contextobd.Citas.Remove(citaParaEliminar);
            contextobd.SaveChanges();
            MessageBox.Show("Cita eliminada correctamente.", "Éxito");
        }
    }
}