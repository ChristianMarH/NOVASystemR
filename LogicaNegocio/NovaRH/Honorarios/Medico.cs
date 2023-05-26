using LogicaNegocio.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.NovaRH.Honorarios
{
    public class Medico
    {
        public static List<Entidades.NovaRH.Honorarios.Medico> Consultar(SqlOpciones pOpcion, string red)
        {
            Entidades.NovaRH.Honorarios.Medico oE = new Entidades.NovaRH.Honorarios.Medico();

            oE.SiglaRed = red;
            DataSet ds = Util.Consultar(pOpcion, oE).Resultado;

            List<Entidades.NovaRH.Honorarios.Medico> res = new List<Entidades.NovaRH.Honorarios.Medico>();
            Entidades.NovaRH.Honorarios.Medico item = null;

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new Entidades.NovaRH.Honorarios.Medico();

                    if (dr.Table.Columns.Contains("IdPersonal"))
                        item.IdPersonal = Convert.ToInt32(dr["IdPersonal"]);

                    if (dr.Table.Columns.Contains("SiglaRed"))
                        item.SiglaRed = Convert.ToString(dr["SiglaRed"]);

                    if (dr.Table.Columns.Contains("Especialidad"))
                        item.Especialidad = Convert.ToString(dr["Especialidad"]);

                    if (dr.Table.Columns.Contains("NombreMedico"))
                        item.NombreMedico = Convert.ToString(dr["NombreMedico"]);

                    if (dr.Table.Columns.Contains("Universidad"))
                        item.Universidad = Convert.ToString(dr["Universidad"]);

                    if (dr.Table.Columns.Contains("CedulaProfesional"))
                        item.CedulaProfesional = Convert.ToString(dr["CedulaProfesional"]);

                    if (dr.Table.Columns.Contains("UniversidadEspecialidad"))
                        item.UniversidadEspecialidad = Convert.ToString(dr["UniversidadEspecialidad"]);

                    if (dr.Table.Columns.Contains("CedulaEspecialidad"))
                        item.CedulaEspecialidad = Convert.ToString(dr["CedulaEspecialidad"]);

                    if (dr.Table.Columns.Contains("Estatus"))
                        item.Estatus = Convert.ToBoolean(dr["Estatus"]);

                    res.Add(item);
                }
            }

            return res;
        }

    }
}
