using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NOVASystemR.Models
{
    public class PermisosModel
    {
        public int UsuarioId { get; set; }
        public int PerfilId { get; set; }
        public int ModuloId { get; set; }
        public int AplicacionId { get; set; }
        public int ProcesoId { get; set; }
        public int ProcesoGeneralId { get; set; }
    }
}