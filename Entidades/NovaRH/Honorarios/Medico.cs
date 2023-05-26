using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.NovaRH.Honorarios
{
    public class Medico
    {
        public int IdPersonal { get; set; }
        public string SiglaRed { get; set; }
        public string Especialidad { get; set; }
        public string NombreMedico { get; set; }
        public string Universidad { get; set; }
        public int CedulaProfesional { get; set; }
        public string UniversidadEspecialidad { get; set; }
        public int CedulaEspecialidad { get; set; }
        public int Estatus { get; set; }
    }

}
