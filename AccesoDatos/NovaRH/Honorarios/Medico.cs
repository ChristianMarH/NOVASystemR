﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NovaRH.Honorarios
{
    public class Medico : Conexion.ConexionSQL
    {
        public Medico()
        {
            NombreConexion = "cxn";
        }

        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.NovaRH.Honorarios.Medico oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                DataSet dsResultado = new DataSet();
                oComando.CommandText = "SpValidaUsuario";
                oComando.CommandType = CommandType.StoredProcedure;

                oComando.Parameters.Clear();

                oParametro = new SqlParameter("@SiglaRed", SqlDbType.VarChar)
                {
                    Value = oBE.SiglaRed
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