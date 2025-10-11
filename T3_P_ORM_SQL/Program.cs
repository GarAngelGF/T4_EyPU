using T3_P_ORM_SQL.Modelos;
using Microsoft.EntityFrameworkCore;

namespace T3_P_ORM_SQL
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var dbContext = new Contextobd();

            // 2. Usa esa instancia para inicializar la base de datos (si es necesario)
            InicializarDB.Inicializar(dbContext);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // 3. Pasa esa MISMA instancia al formulario Main al crearlo
            Application.Run(new Main(dbContext));
        }
        
    }
}