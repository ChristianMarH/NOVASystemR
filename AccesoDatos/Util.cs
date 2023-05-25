using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class DUtil : Conexion.ConexionSQL
    {
        public DUtil()
        {
            NombreConexion = "cxn";
        }

        public bool EnviaDataTabla(DataTable dt, string NombreTablaEnSqlQueRecibeEl_dt, List<string> camposDestino, string Esquema)
        {
            try
            {
                oComando.CommandText = string.Format("TRUNCATE TABLE {0}.{1}", Esquema, NombreTablaEnSqlQueRecibeEl_dt);
                oComando.CommandType = CommandType.Text;
                if (this.Conectar())
                {
                    oComando.ExecuteNonQuery();
                    SqlBulkCopy sqlbulk = new SqlBulkCopy(oConexion)
                    {
                        DestinationTableName = Esquema + ((Esquema == string.Empty) ? "" : ".") + NombreTablaEnSqlQueRecibeEl_dt
                    };

                    sqlbulk.WriteToServer(dt);

                    Desconectar();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public EntidadResponse EjecutaSpTask(string spNombre, Dictionary<string, dynamic> parametros, bool TraeDatos)
        {
            EntidadResponse res = new EntidadResponse();
            try
            {

                if (this.Conectar())
                {
                    oComando.CommandText = spNombre;
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 600000;
                    if (parametros != null)
                        foreach (KeyValuePair<string, dynamic> parametro in parametros)
                        {
                            SqlParameter param = new SqlParameter
                            {
                                Value = parametro.Value,
                                ParameterName = string.Format("{0}{1}", "@", parametro.Key)
                            };
                            oComando.Parameters.Add(param);
                        }
                    if (!TraeDatos)
                    {
                        SqlDataReader sdr = oComando.ExecuteReader();
                    }
                    else
                    {
                        SqlDataAdapter sda = new SqlDataAdapter(oComando);
                        sda.Fill(res.Resultado);
                    }
                    GC.Collect();
                    res.Error = false;
                    return res;
                }
                res.Error = true;
                return res;
            }
            catch (Exception e)
            {
                SqlException ex = null;
                string procedimiento = string.Empty;
                if (e.GetType() == typeof(SqlException))
                {
                    ex = (SqlException)e;
                }

                res.Error = true;
                res.MensajeError = string.Format("Mensaje: {0} \r\n Stacktrace: {1} \r\n Procedimiento: {2} \r\n Linea: {3}, TipoError: {4}", ex.Message, ex.StackTrace, ex.Procedure, ex.LineNumber, ex.Number);

                return res;
            }

        }


        public EntidadResponse EjecutaSp(string spNombre, Dictionary<string, dynamic> parametros, bool TraeDatos)
        {
            EntidadResponse res = new EntidadResponse();
            try
            {

                if (this.Conectar())
                {
                    oComando.CommandText = spNombre;
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 600000;
                    //if (parametros != null)
                    foreach (KeyValuePair<string, dynamic> parametro in parametros)
                    {
                        SqlParameter param = new SqlParameter
                        {
                            Value = parametro.Value,
                            ParameterName = string.Format("{0}{1}", "@", parametro.Key)
                        };
                        oComando.Parameters.Add(param);
                    }
                    if (!TraeDatos)
                    {
                        SqlDataReader sdr = oComando.ExecuteReader();
                    }
                    else
                    {
                        SqlDataAdapter sda = new SqlDataAdapter(oComando);
                        sda.Fill(res.Resultado);
                    }
                    GC.Collect();
                    res.Error = false;
                    return res;
                }
                res.Error = true;
                return res;
            }
            catch (Exception e)
            {
                SqlException ex = null;
                string procedimiento = string.Empty;
                if (e.GetType() == typeof(SqlException))
                {
                    ex = (SqlException)e;
                }

                res.Error = true;
                res.MensajeError = string.Format("Mensaje: {0} \r\n Stacktrace: {1} \r\n Procedimiento: {2} \r\n Linea: {3}, TipoError: {4}", ex.Message, ex.StackTrace, ex.Procedure, ex.LineNumber, ex.Number);

                return res;
            }

        }
    }
}