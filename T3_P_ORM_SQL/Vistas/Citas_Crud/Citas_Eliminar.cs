using System;
using System.Windows.Forms;
using T3_P_ORM_SQL.Controladores;
using T3_P_ORM_SQL.Excepciones;
using T3_P_ORM_SQL.Modelos;

namespace T3_P_ORM_SQL.Vistas.Citas_Crud
{
  
    public partial class Citas_Eliminar : Form
    {
        private readonly CitasController<Citas_Eliminar> controller;
        private readonly Contextobd contextobd;

        public Citas_Eliminar(Contextobd contexto)
        {
            InitializeComponent();
            this.contextobd = contexto;
            controller = new CitasController<Citas_Eliminar>(this, contextobd);
        }

        private void Citas_Eliminar_Load(object sender, EventArgs e)
        {
            VerCitas();
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

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (DgvCitas.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una cita para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                dynamic citaSeleccionada = DgvCitas.CurrentRow.DataBoundItem;
                int citaId = citaSeleccionada.IdDeLaCita;

                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar la cita con Id " + citaId + "?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    controller.OnEliminar(citaId);
                    VerCitas();
                }
            }
            catch (DatosInvalidosException ex)
            {
                MessageBox.Show(ex.Message, "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}