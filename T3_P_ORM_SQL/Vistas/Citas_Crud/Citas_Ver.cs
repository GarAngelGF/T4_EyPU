using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T3_P_ORM_SQL.Controladores;
using T3_P_ORM_SQL.Modelos;

namespace T3_P_ORM_SQL.Vistas.Citas_Crud
{
    // Formulario para visualizar la lista de citas existentes.
    public partial class Citas_Ver : Form
    {
        // Referencia al controlador que maneja la lógica de negocio.
        private readonly CitasController<Citas_Ver> controller;
        // Referencia al contexto de la base de datos.
        private readonly Contextobd contextobd;

        // Constructor del formulario.
        internal Citas_Ver(Contextobd contexto)
        {
            InitializeComponent();
            this.contextobd = contexto;
            // Inicializa el controlador, pasándole una referencia a este formulario y al contexto de la BD.
            controller = new CitasController<Citas_Ver>(this, contextobd);
        }

        // Método encargado de cargar y mostrar los datos de las citas en el DataGridView.
        public void VerCitas()
        {
            // Asigna el origen de datos del DataGridView al resultado del método del controlador.
            DgvCitas.DataSource = controller.OnVerCitas();

            // Oculta las columnas que contienen los IDs para que no sean visibles al usuario.
            if (DgvCitas.Columns.Contains("IdDelPaciente"))
                DgvCitas.Columns["IdDelPaciente"].Visible = false;
            if (DgvCitas.Columns.Contains("IdDelMedico"))
                DgvCitas.Columns["IdDelMedico"].Visible = false;
        }

        // Evento que se ejecuta cuando el formulario se carga por primera vez.
        private void Citas_Ver_Load(object sender, EventArgs e)
        {
            // Llama al método para poblar el DataGridView con los datos de las citas.
            VerCitas();
        }
    }
}