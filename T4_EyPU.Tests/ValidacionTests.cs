using Microsoft.VisualStudio.TestTools.UnitTesting;
using T3_P_ORM_SQL.Utilidades; //para las utilidades de rfc que esta en validacion

namespace T3_P_ORM_SQL.Tests
{
    [TestClass] 
    public class ValidacionTests
    {
        [TestMethod] 
        public void RfcValidoConCaracteresValidos()
        {
            // datos de entrada.
            string rfcValido = "GOPE950101HDA";

            // Ejecutamos el método que queremos probar.
            bool resultado = Validadores.EsRfcValido(rfcValido);

            // Verificamos que el resultado es el que esperamos.
            Assert.IsTrue(resultado, "Un RFC válido debería ser aceptado.");
        }

        [TestMethod]
        public void RfcValidoConCaracteresInvalidos()
        {
            
            string rfcInvalido = "GOPE950101-DA"; // Contiene un guion(error en el rfc)

            
            bool resultado = Validadores.EsRfcValido(rfcInvalido);

            
            Assert.IsFalse(resultado, "Un RFC con guiones no es válido.");
        }

        [TestMethod]
        public void RfcValidoConCaracteresNULL()
        {
           
            string rfcNulo = null;

           
            bool resultado = Validadores.EsRfcValido(rfcNulo);

           
            Assert.IsFalse(resultado, "Un RFC nulo no es válido.");
        }
    }
}
