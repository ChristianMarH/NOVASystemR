using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.WS_SAI
{
    public class Seguridad
    {
        public const int SistemaId = 29;

        public static Boolean AutenticarUsuario(string pDominio, string pCuentaRed, string pContrasena)
        {
            SAI.SAIClient oSAI = new SAI.SAIClient();

            SAI.Autenticar oAutenticar = oSAI.AutenticarUsuario(pDominio, pCuentaRed, pContrasena, SistemaId);

            return oAutenticar.AutenticacionCorrecta;
        }

        public static Entidades.SAI.Usuario ObtenerPermisos(string pCuentaRed)
        {
            SAI.SAIClient oSAI = new SAI.SAIClient();
            Entidades.SAI.Usuario res = new Entidades.SAI.Usuario();

            DataSet dsUsuario = oSAI.ObtenerPermisos(SistemaId, pCuentaRed);

            if (dsUsuario != null && dsUsuario.Tables.Count > 0 && dsUsuario.Tables[0].Rows.Count > 0)
            {
                DataRow dr = dsUsuario.Tables[0].Rows[0];
                res.UsuarioId = int.Parse(dr["UsuarioId"].ToString());
                res.CuentaRed = dr["Usuario"].ToString();
                res.Nombre = dr["Nombre"].ToString();
                res.NombreCompleto = string.Format("{0} {1}", dr["Nombre"], dr["Apellido"]).ToUpper();
                res.Correo = dr["Correo"].ToString();
                res.Foto = dr["Foto"] as byte[];
            }

            if (dsUsuario != null && dsUsuario.Tables.Count > 1)
            {
                res.Permisos = dsUsuario.Tables[1];
            }
            if (dsUsuario != null && dsUsuario.Tables.Count > 2)
            {
                res.Perfiles = dsUsuario.Tables[2];
            }
            return res;
        }

        public static Entidades.SAI.Usuario ObtenerCorreoElectronicoSAI(string pCuentaRed)
        {
            SAI.SAIClient oSAI = new SAI.SAIClient();
            Entidades.SAI.Usuario res = new Entidades.SAI.Usuario();

            DataSet dsUsuario = oSAI.ObtenerUsuario("Ternium", pCuentaRed);

            if (dsUsuario != null && dsUsuario.Tables.Count > 0 && dsUsuario.Tables[0].Rows.Count > 0)
            {
                DataRow dr = dsUsuario.Tables[0].Rows[0];
                res.Correo = dr["Correo"].ToString();
                res.UsuarioId = int.Parse(dr["UsuarioId"].ToString());
                res.CuentaRed = dr["Usuario"].ToString();
                res.Nombre = dr["Nombre"].ToString();
                res.NombreCompleto = string.Format("{0} {1}", dr["Nombre"], dr["Apellido"]).ToUpper();
                //res.Foto = dr["Foto"] as byte[];
            }

            return res;
        }
    }
}
