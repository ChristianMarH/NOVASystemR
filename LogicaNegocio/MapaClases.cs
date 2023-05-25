using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public static class MapaClases
    {
        public static dynamic EntityToData(object oBE)
        {
            Dictionary<object, object> DataList = new Dictionary<object, object>();

         
           
            DataList.Add(typeof(Entidades.NovaRH.Honorarios.Configuracion), typeof(AccesoDatos.NovaRH.Honorarios.Configuracion));
           
            dynamic valor;

            if (DataList.TryGetValue(oBE.GetType(), out valor))
            {
                return valor;
            }

            return typeof(object);
        }
    }
}
