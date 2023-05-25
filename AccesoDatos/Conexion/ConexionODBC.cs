using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Conexion
{
    public class ConexionODBC
    {
        public string NombreConexion = "cxnVigencia";
        public OdbcConnection oConexion = new OdbcConnection();
        public OdbcCommand oComando;
        public OdbcParameter oParametro;
        public OdbcDataAdapter oAdaptador;

        public ConexionODBC()
        {
            oComando = new OdbcCommand();
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
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                    //BusinessUtils.Logger.WriteLogFile(ex.Message);
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
                throw;
            }
        }
    }
}
