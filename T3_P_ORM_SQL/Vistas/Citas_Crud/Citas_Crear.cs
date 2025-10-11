using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T3_P_ORM_SQL.Controladores;
using T3_P_ORM_SQL.Modelos;

namespace T3_P_ORM_SQL.Vistas.Citas_Crud
{
    // Formulario para la creación de nuevas citas.
    public partial class Citas_Crear : Form
    {
        // Referencia al controlador que maneja la lógica de negocio.
        private readonly CitasController<Citas_Crear> controller;
        // Referencia al contexto de la base de datos.
        private readonly Contextobd contextobd;

        // Constructor del formulario.
        internal Citas_Crear(Contextobd contexto)
        {
            InitializeComponent();
            this.contextobd = contexto;
            // Inicializa el controlador, pasándole una referencia a este formulario y al contexto de la BD.
            controller = new CitasController<Citas_Crear>(this, contextobd);
        }

        // Evento que se ejecuta cuando el formulario se carga por primera vez.
        private void Citas_Crear_Load(object sender, EventArgs e)
        {
            // Carga los datos iniciales en los ComboBox.
            CargarDoctor();
            CargarPaciente();
            CargarHorario();
            // Configura el calendario para permitir seleccionar solo desde hoy hasta 30 días en el futuro.
            monthCalendar1.MinDate = DateTime.Today;
            monthCalendar1.MaxDate = DateTime.Today.AddDays(30);
        }

        // Carga la lista de doctores en su respectivo ComboBox.
        private void CargarDoctor()
        {
            CmbDoctor.DataSource = controller.OnCargarDoctor();
            CmbDoctor.DisplayMember = "DisplayText"; // Lo que el usuario ve.
            CmbDoctor.ValueMember = "Id"; // El valor oculto.
        }

        // Carga la lista de pacientes en su respectivo ComboBox.
        private void CargarPaciente()
        {
            CmbPaciente.DataSource = controller.ONCargarPaciente();
            CmbPaciente.DisplayMember = "Nombre";
            CmbPaciente.ValueMember = "Id";
        }

        // Carga la lista de horarios disponibles en su respectivo ComboBox.
        private void CargarHorario()
        {
            CmbHorario.DataSource = controller.OnCargarHorario();
        }

        // Evento que se dispara al hacer clic en el botón "Agendar".
        private void BtnAgendar_Click(object sender, EventArgs e)
        {
            // Obtiene los objetos completos de Doctor y Paciente seleccionados en los ComboBox.
            var comboBox = CmbDoctor as ComboBox;
            var comboBox1 = CmbPaciente as ComboBox;

            if (comboBox == null && comboBox1 == null)
            {
                return;
            }

            Doctor doctorSeleccionado = comboBox.SelectedItem as Doctor;
            Paciente pacienteSeleccionado = comboBox1.SelectedItem as Paciente;

            // Recopila los datos de los controles del formulario.
            string horaTexto = CmbHorario.Text;
            if (string.IsNullOrWhiteSpace(horaTexto)) return;
            string Motivo = textBox1.Text;
            if (string.IsNullOrEmpty(Motivo)) return;

            DateTime fechaSeleccionada = monthCalendar1.SelectionStart.Date;

            // Combina la fecha del calendario con la hora del ComboBox para crear un DateTime completo.
            if (TimeSpan.TryParse(horaTexto, out TimeSpan horaseleecionada))
            {
                DateTime fechaYHoraDeLaCita;
                fechaYHoraDeLaCita = fechaSeleccionada + horaseleecionada;

                // Llama al método del controlador para guardar la nueva cita.
                controller.OnAgendarCitas(doctorSeleccionado, pacienteSeleccionado, fechaYHoraDeLaCita, Motivo);
            }
        }

        // Evento que se dispara cada vez que cambia la selección en el ComboBox de doctores.
        private void CmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Realiza una validación en tiempo real para verificar si el doctor tiene un conflicto de horario.
            var comboBox = sender as ComboBox;
            if (comboBox == null) return;

            Doctor doctorSeleccionado = comboBox.SelectedItem as Doctor;
            if (doctorSeleccionado == null) return;

            string horaTexto = CmbHorario.Text;
            if (string.IsNullOrWhiteSpace(horaTexto)) return;

            DateTime fechaSeleccionada = monthCalendar1.SelectionStart.Date;

            if (TimeSpan.TryParse(horaTexto, out TimeSpan horaseleecionada))
            {
                DateTime fechaYHoraDeLaCita = fechaSeleccionada + horaseleecionada;

                // Si el controlador detecta un conflicto, muestra un mensaje.
                if (controller.OnValidarConflicto(doctorSeleccionado, fechaYHoraDeLaCita))
                {
                    MessageBox.Show($"El Dr {doctorSeleccionado.Nombre} ya tiene una cita a las {fechaYHoraDeLaCita}");
                }
            }
        }

        // Evento que se dispara cada vez que cambia la selección en el ComboBox de pacientes.
        private void CmbPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Realiza una validación en tiempo real para verificar si el paciente ya tiene una cita a esa hora.
            var comboBox = sender as ComboBox;
            if (comboBox == null) return;

            Paciente pacienteSeleccionado = comboBox.SelectedItem as Paciente;
            if (pacienteSeleccionado == null) return;

            string horaTexto = CmbHorario.Text;
            if (string.IsNullOrWhiteSpace(horaTexto)) return;

            DateTime fechaSeleccionada = monthCalendar1.SelectionStart.Date;

            if (TimeSpan.TryParse(horaTexto, out TimeSpan horaseleecionada))
            {
                DateTime fechaYHoraDeLaCita = fechaSeleccionada + horaseleecionada;

                // Si el controlador detecta un conflicto, muestra un mensaje.
                if (controller.OnNoCitaPrevia(pacienteSeleccionado, fechaYHoraDeLaCita))
                {
                    MessageBox.Show($"El paciente {pacienteSeleccionado.Nombre} {pacienteSeleccionado.ApellidoP} ya tiene una cita a las {fechaYHoraDeLaCita:dd/MM/yyyy HH:mm}");
                }
            }
        }
    }
}