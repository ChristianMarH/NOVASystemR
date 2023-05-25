using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.NovaRH.Honorarios
{
    public class Configuracion
    {
        public static IList<Entidades.NovaRH.Honorarios.Configuracion> Consultar(SqlOpciones pOpcion, string busqueda)
        {
            IList<Entidades.NovaRH.Honorarios.Configuracion> res = new List<Entidades.NovaRH.Honorarios.Configuracion>();
            Entidades.NovaRH.Honorarios.Configuracion item = new Entidades.NovaRH.Honorarios.Configuracion() { Nombre = busqueda };

            DataSet ds = Util.Consultar(pOpcion, item).Resultado;

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new Entidades.NovaRH.Honorarios.Configuracion();

                    if (dr.Table.Columns.Contains("Descripcion"))
                        item.Descripcion = dr["Descripcion"].ToString();

                    if (dr.Table.Columns.Contains("Valor"))
                        item.Valor = dr["Valor"].ToString();

                    if (dr.Table.Columns.Contains("Nombre"))
                        item.Nombre = dr["Nombre"].ToString();

                    res.Add(item);
                }
            }

            return res;
        }
    }
}
