using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.NovaRH.Honorarios
{
    public class Configuracion : EntidadBase.EntidadBase
    {
        private string _vcNombre;
        private string _vcDescripcion;
        private string _vcValor;
        public string Nombre { get { return _vcNombre; } set { _vcNombre = value; } }
        public string Descripcion { get { return _vcDescripcion; } set { _vcDescripcion = value; } }
        public string Valor { get { return _vcValor; } set { _vcValor = value; } }
    }
}
