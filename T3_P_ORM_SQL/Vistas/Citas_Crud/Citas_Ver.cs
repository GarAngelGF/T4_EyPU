using System;
using System.Windows.Forms;
using T3_P_ORM_SQL.Controladores;
using T3_P_ORM_SQL.Excepciones; 
using T3_P_ORM_SQL.Modelos;

namespace T3_P_ORM_SQL.Vistas.Citas_Crud
{
    public partial class Citas_Ver : Form
    {
        private readonly CitasController<Citas_Ver> controller;
        private readonly Contextobd contextobd;

        public Citas_Ver(Contextobd contexto)
        {
            InitializeComponent();
            this.contextobd = contexto;
            controller = new CitasController<Citas_Ver>(this, contextobd);
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
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error fatal al cargar los datos: " + ex.Message, "Error General", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
        }

        private void Citas_Ver_Load(object sender, EventArgs e)
        {
            VerCitas();
        }
    }
}