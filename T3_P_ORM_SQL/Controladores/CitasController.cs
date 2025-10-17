using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using T3_P_ORM_SQL.Excepciones; 
using T3_P_ORM_SQL.Modelos;

namespace T3_P_ORM_SQL.Controladores
{
   
    public class CitasController<Tform> where Tform : Form
    {
        private readonly Tform _form;
        private readonly BindingSource vercitasBindinSource;
        private readonly BindingSource verdoctoresBindinSource;
        private readonly BindingSource verpacientesBindinSource;
        private readonly BindingSource verhorarioBindinSource;
        private readonly Contextobd contextobd;

        public CitasController(Tform tform, Contextobd contextobd)
        {
            this.contextobd = contextobd;
            this._form = tform;
            this.vercitasBindinSource = new BindingSource();
            this.verdoctoresBindinSource = new BindingSource();
            this.verpacientesBindinSource = new BindingSource();
            this.verhorarioBindinSource = new BindingSource();
        }

        // TryCF de conexion db
        public BindingSource OnVerCitas()
        {
            try
            {
                var Citas = contextobd.Citas
                    .Include(c => c.DoctorCitas)
                        .ThenInclude(dc => dc.Doctor)
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
           
            catch (Exception ex)
            {
            
                throw new BDConexionException("No se pudo establecer la conexión con la base de datos.", ex);
            }
            finally
            {
                Console.WriteLine("Intento de conexión y consulta de citas finalizado.");
            }
        }

        public BindingSource OnCargarDoctor()
        {
            var Doctor = contextobd.Doctores.ToList();
            verdoctoresBindinSource.DataSource = Doctor;
            return verdoctoresBindinSource;
        }

        public BindingSource ONCargarPaciente()
        {
            var pacientes = contextobd.Pacientes.ToList();
            verpacientesBindinSource.DataSource = pacientes;
            return verpacientesBindinSource;
        }

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

        public bool OnValidarConflicto(Doctor doctor, DateTime Fechayhoraseleccionada)
        {
            int idDelDoctor = doctor.Id;
            bool HayConflicto = contextobd.Citas.Include(dc => dc.DoctorCitas).Any(c => c.FechaHora == Fechayhoraseleccionada && c.DoctorCitas.Any(dc => dc.DoctorId == idDelDoctor));
            return HayConflicto;
        }

        public bool OnNoCitaPrevia(Paciente paciente, DateTime Fechayhoraseleccionada)
        {
            int idDelPaciente = paciente.Id;
            bool HayConflicto = contextobd.Citas
                .Include(dc => dc.PacienteCitas)
                .Any(c => c.FechaHora == Fechayhoraseleccionada &&
                          c.PacienteCitas.Any(dc => dc.PacienteId == idDelPaciente));
            return HayConflicto;
        }

        // TRYC para agendamiento de citas
        public void OnAgendarCitas(Doctor doctor, Paciente paciente, DateTime Fechayhoraseleccionada, string motivo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(motivo))
                {
                    throw new DatosInvalidosException("El motivo de la cita no puede estar vacío.");
                }

                if (OnValidarConflicto(doctor, Fechayhoraseleccionada))
                {
                    throw new CitaNoDisponibleException($"El Dr. {doctor.Nombre} ya tiene una cita programada en esa fecha y hora.");
                }

                if (OnNoCitaPrevia(paciente, Fechayhoraseleccionada))
                {
                    throw new CitaNoDisponibleException($"El paciente {paciente.Nombre} ya tiene una cita programada en esa fecha y hora.");
                }

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
            catch (DbUpdateException ex)
            {
           
                throw new BDConexionException("Error al guardar la nueva cita en la base de datos.", ex);
            }
          
        }

        public void OnModificar(int citaId, int nuevoDoctorId, int nuevoPacienteId, DateTime nuevaFechaHora, string nuevoMotivo)
        {
            // tryc mod
            try
            {
                var citaOriginal = contextobd.Citas.FirstOrDefault(c => c.Id == citaId);
                if (citaOriginal == null)
                {
                    throw new DatosInvalidosException("Error: La cita que intenta modificar no fue encontrada.");
                }

                citaOriginal.FechaHora = nuevaFechaHora;
                citaOriginal.Motivo = nuevoMotivo;

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

                contextobd.SaveChanges();
                MessageBox.Show("Cita actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DbUpdateException ex)
            {
                throw new BDConexionException("Ocurrió un error al guardar los cambios en la base de datos.", ex);
            }
        }

        public void OnEliminar(int citaId)
        {
            try
            {
                var citaParaEliminar = contextobd.Citas.FirstOrDefault(c => c.Id == citaId);
                if (citaParaEliminar == null)
                {
                    throw new DatosInvalidosException("La cita que intenta eliminar no existe.");
                }

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
            catch (DbUpdateException ex)
            {
                throw new BDConexionException("Error de base de datos. No se pudo eliminar la cita, es posible que tenga datos relacionados.", ex);
            }
        }
        // Método para calcular el costo de una consulta médica
        public decimal CalcularCostoConsulta(int cantidadEspecialidades)
        {
            const decimal costoBase = 500m; 
            const decimal costoPorEspecialidad = 100m;

            if (cantidadEspecialidades < 0)
            {
                // lo tratamos como 0 para evitar costos negativos.
                cantidadEspecialidades = 0;
            }

            decimal costoTotal = costoBase + (cantidadEspecialidades * costoPorEspecialidad);
            return costoTotal;
        }


    }
}