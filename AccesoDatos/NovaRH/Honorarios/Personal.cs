using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NovaRH.Honorarios
{
    public class Personal : Conexion.ConexionSQL
    {
        public Personal()
        {
            NombreConexion = "cxn";
        }

        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.NovaRH.Honorarios.Personal oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                DataSet dsResultado = new DataSet();
                oComando.CommandText = "Honorarios.spPersonal_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;

                oComando.Parameters.Clear();
                oParametro = new SqlParameter("@Opcion", SqlDbType.SmallInt)
                {
                    Value = Opcion
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@PersonalId", SqlDbType.Int)
                {
                    Value = oBE.PersonalId
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@PersonalDescripcion", SqlDbType.VarChar)
                {
                    Value = oBE.PersonalDescripcion
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@Baja", SqlDbType.Bit)
                {
                    Value = oBE.Baja
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@FiltroPersonal", SqlDbType.Int)
                {
                    Value = oBE.FiltroPersonal
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@UsuarioRed", SqlDbType.VarChar)
                {
                    Value = oBE.UsuarioRed
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
