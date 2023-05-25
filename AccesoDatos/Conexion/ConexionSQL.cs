using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace AccesoDatos.Conexion
{
    public class ConexionSQL
    {
        public string NombreConexion = "cxnDessa";
        public SqlConnection oConexion = new SqlConnection();
        public SqlCommand oComando;
        public SqlParameter oParametro;
        public SqlDataAdapter oAdaptador;

        public ConexionSQL()
        {
            oComando = new SqlCommand();
        }

        public bool Conectar()
        {
            oConexion.ConnectionString = ConfigurationManager.ConnectionStrings[NombreConexion].ConnectionString;

            if (oConexion.State == ConnectionState.Closed)
            {
                try
                {
                    oConexion.Open();
                    oComando.Connection = oConexion;
                    return true;
                }
                catch
                {

                }
            }

            return false;
        }

        public void Desconectar()
        {
            try
            {
                oConexion.Close();
            }
            catch
            {
            }
        }
    }
}
