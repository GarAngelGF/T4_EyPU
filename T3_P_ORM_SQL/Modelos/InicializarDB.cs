using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_P_ORM_SQL.Modelos
{
    internal class InicializarDB
    {
        public static void Inicializar(Contextobd _contextDB)
        {
            _contextDB.Database.EnsureCreated();

            // Revisa si ya hay citas para no duplicar los datos
            if (_contextDB.Citas.Any())
            {
                return; // La base de datos ya ha sido inicializada
            }

            // 1. Crear Doctores
            var doctores = new Doctor[]
            {
                new Doctor("GOPJ850101", "Juan", "Gómez", "Pérez", "5512345678", "Cardiología", "12345"),
                new Doctor("RAML900202", "Luisa", "Ramírez", "López", "5587654321", "Pediatría", "67890"),
                new Doctor("SORM780303", "Mario", "Solis", "Ruiz", "5511223344", "Médico General", "11223")
            };
            _contextDB.Doctores.AddRange(doctores);
            _contextDB.SaveChanges(); // Guardamos para que EF asigne los IDs

            // 2. Crear Pacientes
            var pacientes = new Paciente[]
            {
                new Paciente("Carlos", "Sánchez", "García", 45, "5555667788"),
                new Paciente("Ana", "Martínez", "Hernández", 8, "5599887766"),
                new Paciente("Pedro", "Jiménez", "Vargas", 30, "5533445566"),
                new Paciente("Sofía", "Luna", "Mora", 25, "5522114477")
            };
            _contextDB.Pacientes.AddRange(pacientes);
            _contextDB.SaveChanges(); // Guardamos para que EF asigne los IDs

            // 3. Crear Citas
            var citas = new Cita[]
            {
                new Cita(DateTime.Now.AddDays(1).Date.AddHours(10), "Revisión Cardiológica Anual"),
                new Cita(DateTime.Now.AddDays(1).Date.AddHours(12), "Vacuna de Refuerzo"),
                new Cita(DateTime.Now.AddDays(2).Date.AddHours(9), "Consulta General por Gripe"),
                new Cita(DateTime.Now.AddDays(2).Date.AddHours(11), "Consulta Pediátrica")
            };
            _contextDB.Citas.AddRange(citas);
            _contextDB.SaveChanges(); // Guardamos para que EF asigne los IDs

            // 4. Crear las relaciones en las tablas intermedias
            var relaciones = new object[]
            {
                // Cita 1: Dr. Juan (ID=1) con Paciente Carlos (ID=1)
                new Inter_Doc_Cita { DoctorId = doctores[0].Id, CitaId = citas[0].Id },
                new Inter_Paciente_Cita { PacienteId = pacientes[0].Id, CitaId = citas[0].Id },

                // Cita 2: Dra. Luisa (ID=2) con Paciente Ana (ID=2)
                new Inter_Doc_Cita { DoctorId = doctores[1].Id, CitaId = citas[1].Id },
                new Inter_Paciente_Cita { PacienteId = pacientes[1].Id, CitaId = citas[1].Id },

                // Cita 3: Dr. Mario (ID=3) con Paciente Pedro (ID=3)
                new Inter_Doc_Cita { DoctorId = doctores[2].Id, CitaId = citas[2].Id },
                new Inter_Paciente_Cita { PacienteId = pacientes[2].Id, CitaId = citas[2].Id },

                // Cita 4: Dra. Luisa (ID=2) con Paciente Sofía (ID=4)
                new Inter_Doc_Cita { DoctorId = doctores[1].Id, CitaId = citas[3].Id },
                new Inter_Paciente_Cita { PacienteId = pacientes[3].Id, CitaId = citas[3].Id }
            };

            foreach (var relacion in relaciones)
            {
                _contextDB.Add(relacion);
            }

            _contextDB.SaveChanges(); // Guardamos todas las relaciones
        }
    }
}
