using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NOVASystemR.Models
{
    public class MedicoModel
    {
        public int IdPersonal { get; set; }
        public string SiglaRed { get; set; }
        public string Especialidad { get; set; }
        public string NombreMedico { get; set; }
        public string Universidad { get; set; }
        public string CedulaProfesional { get; set; }
        public string UniversidadEspecialidad { get; set; }
        public string CedulaEspecialidad { get; set; }
        public bool Estatus { get; set; }
    }
}