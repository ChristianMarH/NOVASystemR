using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.EntidadBase
{
    public class EntidadResponseModel
    {
        public dynamic Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
