using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades.NovaRH.Honorarios
{
    public class Personal : EntidadBase.EntidadBase
    {
        public Personal()
        {
            _PersonalDescripcion = string.Empty;
            _Tarifa = 0;
        }

        Int32 _PersonalId;
        public Int32 PersonalId { get { return _PersonalId; } set { _PersonalId = value; } }

        Int32 _CoordinadorId;
        public Int32 CoordinadorId { get { return _CoordinadorId; } set { _CoordinadorId = value; } }

        String _PersonalDescripcion;
        [StringLength(100)]
        public String PersonalDescripcion { get { return _PersonalDescripcion; } set { _PersonalDescripcion = value; } }

        String _Paterno;
        [StringLength(100)]
        public String Paterno { get { return _Paterno; } set { _Paterno = value; } }

        String _Materno;
        [StringLength(100)]
        public String Materno { get { return _Materno; } set { _Materno = value; } }

        String _Nombre;
        [StringLength(100)]
        public String Nombre { get { return _Nombre; } set { _Nombre = value; } }

        String _CURP;
        [StringLength(100)]
        public String CURP { get { return _CURP; } set { _CURP = value; } }

        String _CedulaProfesional;
        [StringLength(50)]
        public String CedulaProfesional { get { return _CedulaProfesional; } set { _CedulaProfesional = value; } }

        String _RegistroSSA;
        [StringLength(50)]
        public String RegistroSSA { get { return _RegistroSSA; } set { _RegistroSSA = value; } }

        String _CodigoUsuario;
        [StringLength(50)]
        public String CodigoUsuario { get { return _CodigoUsuario; } set { _CodigoUsuario = value; } }

        String _UsuarioRed;
        [StringLength(100)]
        public String UsuarioRed { get { return _UsuarioRed; } set { _UsuarioRed = value; } }

        Int16 _PersonalTipoId;
        public Int16 PersonalTipoId { get { return _PersonalTipoId; } set { _PersonalTipoId = value; } }

        Boolean? _SistemaActivo;
        public Boolean? SistemaActivo { get { return _SistemaActivo; } set { _SistemaActivo = value; } }

        Boolean? _SistemaNoVence;
        public Boolean? SistemaNoVence { get { return _SistemaNoVence; } set { _SistemaNoVence = value; } }

        DateTime? _SistemaIngreso;
        public DateTime? SistemaIngreso { get { return _SistemaIngreso; } set { _SistemaIngreso = value; } }

        DateTime? _SistemaBaja;
        public DateTime? SistemaBaja { get { return _SistemaBaja; } set { _SistemaBaja = value; } }

        Boolean? _Suspension;
        public Boolean? Suspension { get { return _Suspension; } set { _Suspension = value; } }

        DateTime? _SuspensionDesde;
        public DateTime? SuspensionDesde { get { return _SuspensionDesde; } set { _SuspensionDesde = value; } }

        DateTime? _SuspensionHasta;
        public DateTime? SuspensionHasta { get { return _SuspensionHasta; } set { _SuspensionHasta = value; } }

        String _CodigoSAP;
        [StringLength(20)]
        public String CodigoSAP { get { return _CodigoSAP; } set { _CodigoSAP = value; } }

        String _PersonalSAP;
        [StringLength(20)]
        public String PersonalSAP { get { return _PersonalSAP; } set { _PersonalSAP = value; } }

        String _MedidaTipoId;
        public String MedidaTipoId { get { return _MedidaTipoId; } set { _MedidaTipoId = value; } }

        Decimal? _Tarifa;
        public Decimal? Tarifa { get { return _Tarifa; } set { _Tarifa = value; } }

        Int32? _CentroCostoId;
        public Int32? CentroCostoId { get { return _CentroCostoId; } set { _CentroCostoId = value; } }

        Int32? _FiltroPersonal;
        public int? FiltroPersonal { get { return _FiltroPersonal; } set { _FiltroPersonal = value; } }

        DateTime? _InicioContrato;
        public DateTime? InicioContrato { get { return _InicioContrato; } set { _InicioContrato = value; } }

        DateTime? _fincontrato;
        public DateTime? FinContrato { get { return _fincontrato; } set { _fincontrato = value; } }

        String _PuestoDescripcion;
        public String PuestoDescripcion { get { return _PuestoDescripcion; } set { _PuestoDescripcion = value; } }

        Boolean _AplicaIVA;
        public Boolean AplicaIVA { get { return _AplicaIVA; } set { _AplicaIVA = value; } }

        Boolean _AplicaPago;
        public Boolean AplicaPago { get { return _AplicaPago; } set { _AplicaPago = value; } }

        String _RFC;
        public String RFC { get { return _RFC; } set { _RFC = value; } }

        // Se agrega fecha inicio y fin para el historial de unidad de medida(27-12-21)

        DateTime? _Inicio;
        public DateTime? MedidaInicio { get { return _Inicio; } set { _Inicio = value; } }

        DateTime? _fin;
        public DateTime? MedidaFin { get { return _fin; } set { _fin = value; } }

        Int32? _RegimenId;
        public Int32? RegimenId { get { return _RegimenId; } set { _RegimenId = value; } }

        String _CorreoElectronico;
        public String CorreoElectronico { get { return _CorreoElectronico; } set { _CorreoElectronico = value; } }

        String _CorreoElectronicoLocalizacion;
        public String CorreoElectronicoLocalizacion { get { return _CorreoElectronicoLocalizacion; } set { _CorreoElectronicoLocalizacion = value; } }
    }
}
