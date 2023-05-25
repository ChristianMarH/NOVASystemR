using Entidades;
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

        public static EntidadResponse Actualizar(SqlOpciones Opcion, dynamic oBE)
        {
            try
            {
                Type tipoBD = MapaClases.EntityToData(oBE);
                dynamic oBD = Activator.CreateInstance(tipoBD);

                return oBD.Actualizar((short)Opcion, oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EntidadResponse EjecutaSp(string spNombre, Dictionary<string, dynamic> parametros = null, bool TraeDatos = false)
        {
            AccesoDatos.DUtil oDB = new AccesoDatos.DUtil();
            return oDB.EjecutaSpTask(spNombre, parametros, TraeDatos);
        }

        public static EntidadResponse Insertar(SqlOpciones Opcion, dynamic oBE)
        {
            try
            {
                Type tipoBD = MapaClases.EntityToData(oBE);
                dynamic oBD = Activator.CreateInstance(tipoBD);

                return oBD.Insertar((short)Opcion, oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
