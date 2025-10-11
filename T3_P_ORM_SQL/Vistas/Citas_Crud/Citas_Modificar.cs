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
    // Formulario para modificar una cita existente.
    public partial class Citas_Modificar : Form
    {
        // Referencia al controlador y al contexto de la base de datos.
        private readonly CitasController<Citas_Modificar> controller;
        private readonly Contextobd contextobd;

        // Constructor del formulario.
        internal Citas_Modificar(Contextobd contexto)
        {
            InitializeComponent();
            this.contextobd = contexto;
            // Inicializa el controlador, pasándole una referencia a este formulario.
            controller = new CitasController<Citas_Modificar>(this, contextobd);
        }

        // Carga y muestra los datos de las citas en el DataGridView.
        public void VerCitas()
        {
            DgvCitas.DataSource = controller.OnVerCitas();
            // Oculta las columnas de ID para que no sean visibles al usuario.
            if (DgvCitas.Columns.Contains("IdDelPaciente"))
                DgvCitas.Columns["IdDelPaciente"].Visible = false;
            if (DgvCitas.Columns.Contains("IdDelMedico"))
                DgvCitas.Columns["IdDelMedico"].Visible = false;
        }

        // Evento que se ejecuta cuando el formulario se carga por primera vez.
        private void Citas_Modificar_Load(object sender, EventArgs e)
        {
            // Carga todos los datos necesarios.
            VerCitas();
            CargarDoctor();
            CargarPaciente();
            CargarHorario();
            // Deshabilita los controles de edición hasta que se seleccione una cita.
            DesabilitarControles(false, CmbDoctor, CmbPaciente, CmbHorario, textBox1, BtnGuardar, BtnCancelar);
        }

        // Método de utilidad para habilitar o deshabilitar un grupo de controles.
        private void DesabilitarControles(bool habilitar, params Control[] controles)
        {
            foreach (var control in controles)
            {
                control.Enabled = habilitar;
            }
        }

        // Evento del botón "Modificar". Prepara el formulario para la edición.
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            // Valida que se haya seleccionado una fila en el DataGridView.
            if (DgvCitas.Rows.Count < 0)
            {
                MessageBox.Show($"Debe de seleccionar una cita primero", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Obtiene el objeto de la fila seleccionada.
                dynamic citaSeleccionada = DgvCitas.CurrentRow.DataBoundItem;
                DateTime Hora = citaSeleccionada.Fecha;
                string horaFormateada = Hora.ToString("HH:mm");

                // Rellena los controles de edición con los datos de la cita seleccionada.
                CmbDoctor.SelectedValue = citaSeleccionada.IdDelMedico;
                CmbHorario.Text = horaFormateada;
                CmbPaciente.SelectedValue = citaSeleccionada.IdDelPaciente;
                textBox1.Text = citaSeleccionada.MotivoCita;

                // Habilita los controles de edición y deshabilita el botón "Modificar".
                DesabilitarControles(true, CmbDoctor, CmbPaciente, CmbHorario, textBox1, BtnGuardar, BtnCancelar);
                DesabilitarControles(false, BtnModificar);
            }
        }

        // Carga la lista de doctores en su ComboBox.
        private void CargarDoctor()
        {
            CmbDoctor.DataSource = controller.OnCargarDoctor();
            CmbDoctor.DisplayMember = "DisplayText";
            CmbDoctor.ValueMember = "Id";
        }

        // Carga la lista de pacientes en su ComboBox.
        private void CargarPaciente()
        {
            CmbPaciente.DataSource = controller.ONCargarPaciente();
            CmbPaciente.DisplayMember = "Nombre";
            CmbPaciente.ValueMember = "Id";
        }

        // Carga la lista de horarios en su ComboBox.
        private void CargarHorario()
        {
            CmbHorario.DataSource = controller.OnCargarHorario();
        }

        // Evento del botón "Guardar". Aplica los cambios a la cita.
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (DgvCitas.CurrentRow == null) return;

            // Recopila los datos, tanto los originales como los potencialmente modificados.
            dynamic citaSeleccionada = DgvCitas.CurrentRow.DataBoundItem;
            int citaId = citaSeleccionada.IdDeLaCita;
            int doctorId = (int)CmbDoctor.SelectedValue;
            int pacienteId = (int)CmbPaciente.SelectedValue;
            string motivo = textBox1.Text;

            // La fecha no se modifica en este formulario, solo la hora.
            DateTime fechaSeleccionada = citaSeleccionada.Fecha;
            string horaTexto = CmbHorario.Text;
            DateTime nuevaFechaYHora;

            // Combina la fecha original con la nueva hora seleccionada.
            if (TimeSpan.TryParse(horaTexto, out TimeSpan horaSeleccionada))
            {
                nuevaFechaYHora = fechaSeleccionada.Date + horaSeleccionada;
            }
            else
            {
                MessageBox.Show("La hora seleccionada no es válida.");
                return;
            }

            // Llama al controlador para que ejecute la lógica de modificación.
            controller.OnModificar(citaId, doctorId, pacienteId, nuevaFechaYHora, motivo);

            // Restablece el estado del formulario.
            VerCitas();
            DesabilitarControles(false, CmbDoctor, CmbPaciente, CmbHorario, textBox1, BtnGuardar, BtnCancelar);
            DesabilitarControles(true, BtnModificar);
        }

        // Evento del botón "Cancelar". Descarta los cambios y restablece el formulario.
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DesabilitarControles(false, CmbDoctor, CmbPaciente, CmbHorario, textBox1, BtnGuardar, BtnCancelar);
            DesabilitarControles(true, BtnModificar);
        }
    }
}