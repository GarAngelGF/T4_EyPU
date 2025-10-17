using System;
using System.Windows.Forms;
using T3_P_ORM_SQL.Controladores;
using T3_P_ORM_SQL.Excepciones; 
using T3_P_ORM_SQL.Modelos;

namespace T3_P_ORM_SQL.Vistas.Citas_Crud
{
    
    public partial class Citas_Crear : Form
    {
        private readonly CitasController<Citas_Crear> controller;
        private readonly Contextobd contextobd;

        public Citas_Crear(Contextobd contexto)
        {
            InitializeComponent();
            this.contextobd = contexto;
            controller = new CitasController<Citas_Crear>(this, contextobd);
        }

        private void Citas_Crear_Load(object sender, EventArgs e)
        {
            CargarDoctor();
            CargarPaciente();
            CargarHorario();
            monthCalendar1.MinDate = DateTime.Today;
            monthCalendar1.MaxDate = DateTime.Today.AddDays(30);
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

      
        private void BtnAgendar_Click(object sender, EventArgs e)
        {
            try
            {
              
                Doctor doctorSeleccionado = CmbDoctor.SelectedItem as Doctor;
                Paciente pacienteSeleccionado = CmbPaciente.SelectedItem as Paciente;
                string horaTexto = CmbHorario.Text;
                string Motivo = textBox1.Text;
                DateTime fechaSeleccionada = monthCalendar1.SelectionStart.Date;

            
                if (doctorSeleccionado == null || pacienteSeleccionado == null || string.IsNullOrWhiteSpace(horaTexto))
                {
                    MessageBox.Show("Por favor, seleccione un doctor, un paciente y un horario.", "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

          
                if (TimeSpan.TryParse(horaTexto, out TimeSpan horaseleccionada))
                {
                    DateTime fechaYHoraDeLaCita = fechaSeleccionada + horaseleccionada;

                   
                    controller.OnAgendarCitas(doctorSeleccionado, pacienteSeleccionado, fechaYHoraDeLaCita, Motivo);

          
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El formato de la hora no es válido.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
            catch (CitaNoDisponibleException ex)
            {
                MessageBox.Show(ex.Message, "Conflicto de Horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void CmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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

                
                if (controller.OnValidarConflicto(doctorSeleccionado, fechaYHoraDeLaCita))
                {
                    MessageBox.Show($"El Dr {doctorSeleccionado.Nombre} ya tiene una cita a las {fechaYHoraDeLaCita}");
                }
            }
        }

        
        private void CmbPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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

               
                if (controller.OnNoCitaPrevia(pacienteSeleccionado, fechaYHoraDeLaCita))
                {
                    MessageBox.Show($"El paciente {pacienteSeleccionado.Nombre} {pacienteSeleccionado.ApellidoP} ya tiene una cita a las {fechaYHoraDeLaCita:dd/MM/yyyy HH:mm}");
                }
            }
        }
    }
}