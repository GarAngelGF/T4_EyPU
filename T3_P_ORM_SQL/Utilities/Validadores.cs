using System.Text.RegularExpressions;

namespace T3_P_ORM_SQL.Utilidades
{
    public static class Validadores 
    {
        public static bool EsRfcValido(string rfc)
        {
            if (string.IsNullOrWhiteSpace(rfc))
            {
                return false; // No puede ser nulo o vacío
            }

            rfc = rfc.ToUpper().Trim(); // Limpiamos y estandarizamos la entrada

            //expresión regular para validar el formato del RFC
            var regex = new Regex(@"^[A-Z&Ñ]{3,4}\d{6}[A-Z\d]{3}$");

            return regex.IsMatch(rfc);
        }
    }
}
