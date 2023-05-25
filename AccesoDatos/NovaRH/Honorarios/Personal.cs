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

        public Entidades.EntidadResponse Actualizar(short Option, Entidades.NovaRH.Honorarios.Personal oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                DataSet dsResultado = new DataSet();
                oComando.CommandText = "Honorarios.spPersonal_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.CommandTimeout = 500;

                oComando.Parameters.Clear();
                oParametro = new SqlParameter("@Opcion", SqlDbType.SmallInt)
                {
                    Value = Option
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@PersonalId", SqlDbType.Int)
                {
                    Value = oBE.PersonalId
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@RFC", SqlDbType.VarChar)
                {
                    Value = oBE.RFC
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@CodigoSAP", SqlDbType.VarChar)
                {
                    Value = oBE.CodigoSAP
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@PersonalSAP", SqlDbType.VarChar)
                {
                    Value = oBE.PersonalSAP
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@MedidaTipoId", SqlDbType.VarChar)
                {
                    Value = oBE.MedidaTipoId
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@Tarifa", SqlDbType.Decimal)
                {
                    Value = oBE.Tarifa
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@CentroCostoId", SqlDbType.Int)
                {
                    Value = oBE.CentroCostoId
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@InicioContrato", SqlDbType.DateTime)
                {
                    Value = oBE.InicioContrato
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@FinContrato", SqlDbType.DateTime)
                {
                    Value = oBE.FinContrato
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@AplicaIVA", SqlDbType.Bit)
                {
                    Value = oBE.AplicaIVA
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@AplicaPago", SqlDbType.Bit)
                {
                    Value = oBE.AplicaPago
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@UsuarioModificacionId", SqlDbType.Int)
                {
                    Value = oBE.UsuarioModificacionId
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@FechaModificacion", SqlDbType.DateTime)
                {
                    Value = oBE.FechaModificacion
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@UsuarioBajaId", SqlDbType.Int)
                {
                    Value = oBE.UsuarioBajaId
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@FechaBaja", SqlDbType.DateTime)
                {
                    Value = oBE.FechaBaja
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@Baja", SqlDbType.Bit)
                {
                    Value = oBE.Baja
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@dMedidaInicio", SqlDbType.DateTime)
                {
                    Value = oBE.MedidaInicio
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@dMedidaFin", SqlDbType.DateTime)
                {
                    Value = oBE.MedidaFin
                };
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@RegimenFiscalId", SqlDbType.Int)
                {
                    Value = oBE.RegimenId
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
