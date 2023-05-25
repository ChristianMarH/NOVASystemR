using System.Data;

namespace Entidades
{
    public class EntidadResponse
    {
        public EntidadResponse()
        {
            Resultado = new DataSet();
            Error = false;
            MensajeError = string.Empty;
        }

        public DataSet Resultado { get; set; }


        public bool Error { get; set; }


        public string MensajeError { get; set; }
    }
}
