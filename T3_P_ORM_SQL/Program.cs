using System;
using System.Windows.Forms;
using T3_P_ORM_SQL.Modelos;

namespace T3_P_ORM_SQL
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                var dbContext = new Contextobd();
                InicializarDB.Inicializar(dbContext);

                Application.Run(new Main(dbContext));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Parece que hubo un error con la base de datos.\n\nDetalles: " + ex.Message,
                                "Error de arranque",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
            }
        }
    }
}