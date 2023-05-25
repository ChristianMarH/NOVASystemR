using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NovaRH.Honorarios
{
    public class Configuracion : Conexion.ConexionSQL
    {
        public Configuracion()
        {
            NombreConexion = "cxn";
        }

        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.NovaRH.Honorarios.Configuracion oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                DataSet dsResultado = new DataSet();
                oComando.CommandText = "Honorarios.spConfiguraciones_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;

                oComando.Parameters.Clear();
                oParametro = new SqlParameter("@Opcion", SqlDbType.SmallInt)
                {
                    Value = Opcion
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@busqueda", SqlDbType.VarChar)
                {
                    Value = oBE.Nombre
                };
                oComando.Parameters.Add(oParametro);

                if (this.Conectar())
                {
                    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                    daResultado.Fill(oEntidadResponse.Resultado);
                    Desconectar();
                }
            }
            catch (Exception ex)
            {
                oEntidadResponse.Error = true;
                oEntidadResponse.MensajeError = ex.Message;
            }

            return oEntidadResponse;
        }
    }
}
