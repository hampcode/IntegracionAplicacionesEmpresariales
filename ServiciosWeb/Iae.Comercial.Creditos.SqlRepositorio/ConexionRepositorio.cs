using System.Configuration;

namespace Iae.Comercial.Creditos.SqlRepositorio
{
    public class ConexionRepositorio
    {
        public static string ObtenerCadenaConexion()
        {
            return ConfigurationManager.ConnectionStrings["CreditosDB"].ToString();
        }
    }
}
