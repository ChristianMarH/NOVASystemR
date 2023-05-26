using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.NovaRH.Honorarios
{
    public class Medico : EntidadBase.EntidadBase
    {
            public Medico()
            {
                IdPersonal = 0;
                SiglaRed = string.Empty;
                Especialidad = string.Empty;
                NombreMedico = string.Empty;
                Universidad = string.Empty;
                CedulaProfesional = string.Empty;
                UniversidadEspecialidad = string.Empty;
                CedulaEspecialidad = string.Empty;
                Estatus = false;
            }

            public int IdPersonal { get; set; }

            [MaxLength(50)]
            public string SiglaRed { get; set; }

            [MaxLength(100)]
            public string Especialidad { get; set; }

            [MaxLength(100)]
            public string NombreMedico { get; set; }

            [MaxLength(100)]
            public string Universidad { get; set; }

            [MaxLength(50)]
            public string CedulaProfesional { get; set; }

            [MaxLength(100)]
            public string UniversidadEspecialidad { get; set; }

            [MaxLength(50)]
            public string CedulaEspecialidad { get; set; }

            public bool Estatus { get; set; }
        }
}
