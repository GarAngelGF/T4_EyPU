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
    public partial class Citas_Menu : Form
    {
        private readonly Contextobd contextobd;

        // Constructor del formulario que recibe el contexto de la base de datos.
        internal Citas_Menu(Contextobd contextobd)
        {
            InitializeComponent();
            this.contextobd = contextobd;
        }

        private void Citas_Menu_Load(object sender, EventArgs e)
        {

        }

        // Evento que se dispara al hacer clic en el botón para ver las citas.
        private void BtnVer_Click(object sender, EventArgs e)
        {
            // Oculta el menú actual.
            this.Hide();
            // Crea y muestra el formulario para ver las citas.
            Citas_Ver view = new Citas_Ver(contextobd);
            view.Show();
            // Cuando se cierre el formulario de "Ver", vuelve a mostrar este menú.
            view.FormClosed += (s, args) => this.Show();
            // Crea una instancia del controlador para el formulario de "Ver".
            CitasController<Citas_Ver> citas = new CitasController<Citas_Ver>(view, contextobd);
        }

        // Evento que se dispara al hacer clic en el botón para crear una cita.
        private void BtnCrear_Click(object sender, EventArgs e)
        {
            // Oculta el menú actual.
            this.Hide();
            // Crea y muestra el formulario para crear citas.
            Citas_Crear view = new Citas_Crear(contextobd);
            view.Show();
            // Cuando se cierre el formulario de "Crear", vuelve a mostrar este menú.
            view.FormClosed += (s, args) => this.Show();
            // Crea una instancia del controlador para el formulario de "Crear".
            CitasController<Citas_Crear> citas = new CitasController<Citas_Crear>(view, contextobd);
        }

        // Evento que se dispara al hacer clic en el botón para modificar una cita.
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            // Oculta el menú actual.
            this.Hide();
            // Crea y muestra el formulario para modificar citas.
            Citas_Modificar view = new Citas_Modificar(contextobd);
            view.Show();
            // Cuando se cierre el formulario de "Modificar", vuelve a mostrar este menú.
            view.FormClosed += (s, args) => this.Show();
            // Crea una instancia del controlador para el formulario de "Modificar".
            CitasController<Citas_Modificar> citas = new CitasController<Citas_Modificar>(view, contextobd);
        }

        // Evento que se dispara al hacer clic en el botón para eliminar una cita.
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Oculta el menú actual.
            this.Hide();
            // Crea y muestra el formulario para eliminar citas.
            Citas_Eliminar view = new Citas_Eliminar(contextobd);
            view.Show();
            // Cuando se cierre el formulario de "Eliminar", vuelve a mostrar este menú.
            view.FormClosed += (s, args) => this.Show();
            // Crea una instancia del controlador para el formulario de "Eliminar".
            CitasController<Citas_Eliminar> citas = new CitasController<Citas_Eliminar>(view, contextobd);
        }
    }
}