using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntidadJsonResponse
    {
        public int Id { get; set; }

        public string Mensaje { get; set; }

        public string TipoMensaje { get; set; }

        public bool Error { get; set; }

        public string MensajeError { get; set; }
    }
}
