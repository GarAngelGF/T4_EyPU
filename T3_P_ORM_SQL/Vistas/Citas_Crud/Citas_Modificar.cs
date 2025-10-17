using System;
using System.Windows.Forms;
using T3_P_ORM_SQL.Controladores;
using T3_P_ORM_SQL.Excepciones;
using T3_P_ORM_SQL.Modelos;

namespace T3_P_ORM_SQL.Vistas.Citas_Crud
{
    public partial class Citas_Modificar : Form
    {
        private readonly CitasController<Citas_Modificar> controller;
        private readonly Contextobd contextobd;

        public Citas_Modificar(Contextobd contexto)
        {
            InitializeComponent();
            this.contextobd = contexto;
            controller = new CitasController<Citas_Modificar>(this, contextobd);
        }

        public void VerCitas()
        {
            try
            {
                DgvCitas.DataSource = controller.OnVerCitas();
                if (DgvCitas.Columns.Contains("IdDelPaciente"))
                    DgvCitas.Columns["IdDelPaciente"].Visible = false;
                if (DgvCitas.Columns.Contains("IdDelMedico"))
                    DgvCitas.Columns["IdDelMedico"].Visible = false;
            }
            catch (BDConexionException ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
        }

        private void Citas_Modificar_Load(object sender, EventArgs e)
        {
            VerCitas();
            CargarDoctor();
            CargarPaciente();
            CargarHorario();
            DesabilitarControles(false, CmbDoctor, CmbPaciente, CmbHorario, textBox1, BtnGuardar, BtnCancelar);
        }

        private void DesabilitarControles(bool habilitar, params Control[] controles)
        {
            foreach (var control in controles)
            {
                control.Enabled = habilitar;
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (DgvCitas.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una cita primero", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dynamic citaSeleccionada = DgvCitas.CurrentRow.DataBoundItem;
            DateTime Hora = citaSeleccionada.Fecha;
            string horaFormateada = Hora.ToString("HH:mm");

            CmbDoctor.SelectedValue = citaSeleccionada.IdDelMedico;
            CmbHorario.Text = horaFormateada;
            CmbPaciente.SelectedValue = citaSeleccionada.IdDelPaciente;
            textBox1.Text = citaSeleccionada.MotivoCita;

            DesabilitarControles(true, CmbDoctor, CmbPaciente, CmbHorario, textBox1, BtnGuardar, BtnCancelar);
            DesabilitarControles(false, BtnModificar);
        }

        private void CargarDoctor()
        {
            CmbDoctor.DataSource = controller.OnCargarDoctor();
            CmbDoctor.DisplayMember = "Nombre"; 
            CmbDoctor.ValueMember = "Id";
        }

        private void CargarPaciente()
        {
            CmbPaciente.DataSource = controller.ONCargarPaciente();
            CmbPaciente.DisplayMember = "Nombre";
            CmbPaciente.ValueMember = "Id";
        }

        private void CargarHorario()
        {
            CmbHorario.DataSource = controller.OnCargarHorario();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvCitas.CurrentRow == null) return;

                dynamic citaSeleccionada = DgvCitas.CurrentRow.DataBoundItem;
                int citaId = citaSeleccionada.IdDeLaCita;
                int doctorId = (int)CmbDoctor.SelectedValue;
                int pacienteId = (int)CmbPaciente.SelectedValue;
                string motivo = textBox1.Text;
                DateTime fechaSeleccionada = citaSeleccionada.Fecha;
                string horaTexto = CmbHorario.Text;
                DateTime nuevaFechaYHora;

                if (TimeSpan.TryParse(horaTexto, out TimeSpan horaSeleccionada))
                {
                    nuevaFechaYHora = fechaSeleccionada.Date + horaSeleccionada;
                }
                else
                {
                    MessageBox.Show("La hora seleccionada no es válida.");
                    return;
                }

                controller.OnModificar(citaId, doctorId, pacienteId, nuevaFechaYHora, motivo);

                VerCitas();
                DesabilitarControles(false, CmbDoctor, CmbPaciente, CmbHorario, textBox1, BtnGuardar, BtnCancelar);
                DesabilitarControles(true, BtnModificar);
            }
            catch (DatosInvalidosException ex)
            {
                MessageBox.Show(ex.Message, "Datos Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (BDConexionException ex)
            {
                MessageBox.Show(ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DesabilitarControles(false, CmbDoctor, CmbPaciente, CmbHorario, textBox1, BtnGuardar, BtnCancelar);
            DesabilitarControles(true, BtnModificar);
        }
    }
}