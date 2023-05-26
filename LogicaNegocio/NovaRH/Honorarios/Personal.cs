using LogicaNegocio.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.NovaRH.Honorarios
{
    public class Personal
    {
        public static List<Entidades.NovaRH.Honorarios.Personal> Consultar(SqlOpciones pOpcion, int pPersonalId, string pPersonalDescripcion, int pBaja, int FiltroPersonal, string red)
        {
            Entidades.NovaRH.Honorarios.Personal oE = new Entidades.NovaRH.Honorarios.Personal();

            oE.PersonalId = pPersonalId;

            if (pPersonalDescripcion != "")
                oE.PersonalDescripcion = pPersonalDescripcion;
            oE.FiltroPersonal = FiltroPersonal;
            oE.UsuarioRed = red;

            switch (pBaja)
            {
                case 0:
                    oE.Baja = false;
                    break;
                case 1:
                    oE.Baja = true;
                    break;
                default:
                    oE.Baja = null;
                    break;
            }

            DataSet ds = Util.Consultar(pOpcion, oE).Resultado;

            List<Entidades.NovaRH.Honorarios.Personal> res = new List<Entidades.NovaRH.Honorarios.Personal>();
            Entidades.NovaRH.Honorarios.Personal item = null;

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new Entidades.NovaRH.Honorarios.Personal();

                    if (dr.Table.Columns.Contains("PersonalId"))
                        item.PersonalId = Int32.Parse(dr["PersonalId"].ToString());

                    if (dr.Table.Columns.Contains("PersonalDescripcion"))
                        item.PersonalDescripcion = dr["PersonalDescripcion"].ToString();

                    if (dr.Table.Columns.Contains("Paterno"))
                        item.Paterno = dr["Paterno"].ToString();

                    if (dr.Table.Columns.Contains("Materno"))
                        item.Materno = dr["Materno"].ToString();

                    if (dr.Table.Columns.Contains("Nombre"))
                        item.Nombre = dr["Nombre"].ToString();

                    if (dr.Table.Columns.Contains("CURP"))
                        item.CURP = dr["CURP"].ToString();

                    if (dr.Table.Columns.Contains("CedulaProfesional"))
                        item.CedulaProfesional = dr["CedulaProfesional"].ToString();

                    if (dr.Table.Columns.Contains("RegistroSSA"))
                        item.RegistroSSA = dr["RegistroSSA"].ToString();

                    if (dr.Table.Columns.Contains("CodigoUsuario"))
                        item.CodigoUsuario = dr["CodigoUsuario"].ToString();

                    if (dr.Table.Columns.Contains("UsuarioRed"))
                        item.UsuarioRed = dr["UsuarioRed"].ToString();

                    if (dr.Table.Columns.Contains("PersonalTipoId"))
                        item.PersonalTipoId = short.Parse(dr["PersonalTipoId"].ToString());

                    if (dr.Table.Columns.Contains("SistemaActivo"))
                        item.SistemaActivo = String.IsNullOrEmpty(dr["SistemaActivo"].ToString()) ? (bool?)null : bool.Parse(dr["SistemaActivo"].ToString());

                    if (dr.Table.Columns.Contains("SistemaNoVence"))
                        item.SistemaNoVence = String.IsNullOrEmpty(dr["SistemaNoVence"].ToString()) ? (bool?)null : bool.Parse(dr["SistemaNoVence"].ToString());

                    if (dr.Table.Columns.Contains("SistemaIngreso"))
                        item.SistemaIngreso = String.IsNullOrEmpty(dr["SistemaIngreso"].ToString()) ? (DateTime?)null : DateTime.Parse(dr["SistemaIngreso"].ToString());

                    if (dr.Table.Columns.Contains("SistemaBaja"))
                        item.SistemaBaja = String.IsNullOrEmpty(dr["SistemaBaja"].ToString()) ? (DateTime?)null : DateTime.Parse(dr["SistemaBaja"].ToString());

                    if (dr.Table.Columns.Contains("Suspension"))
                        item.Suspension = String.IsNullOrEmpty(dr["Suspension"].ToString()) ? (bool?)null : bool.Parse(dr["Suspension"].ToString());

                    if (dr.Table.Columns.Contains("SuspensionDesde"))
                        item.SuspensionDesde = String.IsNullOrEmpty(dr["SuspensionDesde"].ToString()) ? (DateTime?)null : DateTime.Parse(dr["SuspensionDesde"].ToString());

                    if (dr.Table.Columns.Contains("SuspensionHasta"))
                        item.SuspensionHasta = String.IsNullOrEmpty(dr["SuspensionHasta"].ToString()) ? (DateTime?)null : DateTime.Parse(dr["SuspensionHasta"].ToString());

                    if (dr.Table.Columns.Contains("CodigoSAP"))
                        item.CodigoSAP = dr["CodigoSAP"].ToString();

                    if (dr.Table.Columns.Contains("PersonalSAP"))
                        item.PersonalSAP = dr["PersonalSAP"].ToString();

                    if (dr.Table.Columns.Contains("MedidaTipoId"))
                        item.MedidaTipoId = dr["MedidaTipoId"].ToString();

                    if (dr.Table.Columns.Contains("Tarifa"))
                        item.Tarifa = String.IsNullOrEmpty(dr["Tarifa"].ToString()) ? (Decimal?)0 : Decimal.Parse(dr["Tarifa"].ToString());

                    if (dr.Table.Columns.Contains("CentroCostoId"))
                        item.CentroCostoId = String.IsNullOrEmpty(dr["CentroCostoId"].ToString()) ? (Int32?)null : Int32.Parse(dr["CentroCostoId"].ToString());

                    if (dr.Table.Columns.Contains("Baja"))
                        item.Baja = bool.Parse(dr["Baja"].ToString());

                    if (dr.Table.Columns.Contains("InicioContrato"))
                        item.InicioContrato = String.IsNullOrEmpty(dr["InicioContrato"].ToString()) ? (DateTime?)null : DateTime.Parse(dr["InicioContrato"].ToString());

                    if (dr.Table.Columns.Contains("FinContrato"))
                        item.FinContrato = String.IsNullOrEmpty(dr["FinContrato"].ToString()) ? (DateTime?)null : DateTime.Parse(dr["FinContrato"].ToString());

                    if (dr.Table.Columns.Contains("PuestoDescripcion"))
                        item.PuestoDescripcion = dr["PuestoDescripcion"].ToString();

                    if (dr.Table.Columns.Contains("AplicaIVA"))
                        item.AplicaIVA = bool.Parse(dr["AplicaIVA"].ToString());

                    if (dr.Table.Columns.Contains("AplicaPago"))
                        item.AplicaPago = bool.Parse(dr["AplicaPago"].ToString());

                    if (dr.Table.Columns.Contains("RFC"))
                        item.RFC = dr["RFC"].ToString();

                    if (dr.Table.Columns.Contains("RegimenFiscalId"))
                        item.RegimenId = String.IsNullOrEmpty(dr["RegimenFiscalId"].ToString()) ? (Int32?)null : Int32.Parse(dr["RegimenFiscalId"].ToString());

                    if (dr.Table.Columns.Contains("vcCorreoElectronico"))
                        item.CorreoElectronico = dr["vcCorreoElectronico"].ToString();

                    if (dr.Table.Columns.Contains("vcCorreoElectronicoLocalizacion"))
                        item.CorreoElectronicoLocalizacion = dr["vcCorreoElectronicoLocalizacion"].ToString();
                    res.Add(item);
                }
            }

            return res;
        }



    }
}
