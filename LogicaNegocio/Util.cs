using Entidades.EntidadBase;
using LogicaNegocio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Util
    {
        public static EntidadResponse Consultar(SqlOpciones Opcion, dynamic oBE)
        {
            try
            {
                Type tipoBD = MapaClases.EntityToData(oBE);
                dynamic oBD = Activator.CreateInstance(tipoBD);

                return oBD.Consultar((short)Opcion, oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
