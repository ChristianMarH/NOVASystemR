using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Enum
{
    public enum SqlOpciones
    {
        #region OPCIONES DE CONSULTA
        ConsultaPorId = 1,
        ConsultaGeneral = 2,
        Lista = 3,
        ListaIds = 4,
        ConsultaGeneralConJoin = 4,
        AutenticaUsaurio = 4,
        ConsultaPoblacion = 4,
        ConsultaPersonaPorCURP = 5,
        ConsultaPaquetePersona = 4,
        ConsultaPoblacionPorId = 6,
        ConsultaContratosVigentes = 5,
        ConsultaPersona = 7,
        ConsiltaGeneralContratoProductoPaquete = 5,
        ConsultaPersonal = 4,
        ConsultaEspecialidad = 5,
        Detallado = 1,
        Condensado = 2,
        AgendaSoloGuardias = 3,
        ConsultaFichadaPorMes = 7,
        Lista2 = 4,
        ListaPendientes = 5,
        ConsultaMailMedico = 5,
        ConsultaMailDirector = 6,
        #endregion

        #region OPCIONES DE INSERTAR
        Insertar = 1,
        #endregion

        #region OPCIONES DE ACTUALIZAR
        Actualizar = 1,
        BajaLogica = 2,
        CambioContrasena = 3,
        #endregion

        #region OPCIONES PARA LA BUSQUEDA DE TIPO SE SERVICIOS EN PAQUETE DETALLE
        ConsultaServicios = 4,
        ConsultaMateriales = 5,
        ConsultaMedicamentos = 6,
        ConsultaEstudios = 7,
        ConsultaCirugias = 8,
        #endregion

        #region LISTAS DE NEXUS
        Seleccionar = 1,		//Seleccionar...
        Nuevo = 2,	//Nuevo...
        Todos = 3,	//Todos...
        Actual = 4	//Actual..
        #endregion
    }
}
