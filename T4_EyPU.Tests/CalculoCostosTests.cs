using Microsoft.VisualStudio.TestTools.UnitTesting;
using T3_P_ORM_SQL.Controladores; // Para poder usar nuestro controlller que vamos a testear
using System.Windows.Forms;     

namespace T3_P_ORM_SQL.Tests
{
    [TestClass]
    public class CalculoCostosTests
    {
        [TestMethod]
        public void CalcularCostoSinEspecialidad()//debe de dar 500 que es le costo base
        {
            //aqui no se usa la bd
            var controller = new CitasController<Form>(new Form(), null);
            decimal costoEsperado = 500m;

            
            decimal costoCalculado = controller.CalcularCostoConsulta(0);

            // Assert, verifica si lo que esta en mi proyecto main es igual a lo que espero en la prueba
            Assert.AreEqual(costoEsperado, costoCalculado, "El costo sin especialidades debe ser 500.");
        }

        [TestMethod]
        public void CakcularCostoConTodasLasEspecialidades()
        {
            
            var controller = new CitasController<Form>(new Form(), null);
            decimal costoEsperado = 800m; // el costo base mas 3 especialidades, que es lo que esperamos

            // lo que sale del metodo en el controlador
            decimal costoCalculado = controller.CalcularCostoConsulta(3);

            // Assert, verifica si lo que esta en mi proyecto main es igual a lo que espero en la prueba, que serian 800

            Assert.AreEqual(costoEsperado, costoCalculado, "El costo con 3 especialidades debe ser 800.");
        }
    }
}
