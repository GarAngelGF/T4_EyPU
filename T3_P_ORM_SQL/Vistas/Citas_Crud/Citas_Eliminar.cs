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
    // Formulario para eliminar una cita existente.
    public partial class Citas_Eliminar : Form
    {
        // Referencia al controlador y al contexto de la base de datos.
        private readonly CitasController<Citas_Eliminar> controller;
        private readonly Contextobd contextobd;

        // Constructor del formulario.
        internal Citas_Eliminar(Contextobd contexto)
        {
            InitializeComponent();
            this.contextobd = contexto;
            // Inicializa el controlador, pasándole una referencia a este formulario.
            controller = new CitasController<Citas_Eliminar>(this, contextobd);
        }

        // Evento que se ejecuta cuando el formulario se carga por primera vez.
        private void Citas_Eliminar_Load(object sender, EventArgs e)
        {
            // Muestra la lista de citas al cargar.
            VerCitas();
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

        // Evento del botón para eliminar la cita seleccionada.
        // Nota: El nombre del método es "BtnModificar_Click", pero la lógica es de eliminación.
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            // Obtiene el objeto de la fila actualmente seleccionada en el DataGridView.
            dynamic citaSeleccionada = DgvCitas.CurrentRow.DataBoundItem;

            // Muestra un cuadro de diálogo para confirmar la acción de eliminación.
            DialogResult Resultado = MessageBox.Show("¿Desea eliminar la cita con Id " + citaSeleccionada.IdDeLaCita + "?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Si el usuario confirma la eliminación...
            if (Resultado == DialogResult.Yes)
            {
                // ...llama al método del controlador para eliminar la cita, pasando su ID.
                controller.OnEliminar(citaSeleccionada.IdDeLaCita);
            }

            // Actualiza el DataGridView para reflejar el cambio.
            VerCitas();
        }
    }
}