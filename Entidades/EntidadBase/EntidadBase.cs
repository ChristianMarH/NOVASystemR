using System;

namespace Entidades.EntidadBase
{
    public class EntidadBase
    {
        Int32 _UsuarioCreacionId;
        public Int32 UsuarioCreacionId { get { return _UsuarioCreacionId; } set { _UsuarioCreacionId = value; } }

        DateTime? _FechaCreacion;
        public DateTime? FechaCreacion { get { return _FechaCreacion; } set { _FechaCreacion = value; } }

        Int32 _UsuarioModificacionId;
        public Int32 UsuarioModificacionId { get { return _UsuarioModificacionId; } set { _UsuarioModificacionId = value; } }

        DateTime? _FechaModificacion;
        public DateTime? FechaModificacion { get { return _FechaModificacion; } set { _FechaModificacion = value; } }

        Int32? _UsuarioBajaId;
        public Int32? UsuarioBajaId { get { return _UsuarioBajaId; } set { _UsuarioBajaId = value; } }

        DateTime? _FechaBaja;
        public DateTime? FechaBaja { get { return _FechaBaja; } set { _FechaBaja = value; } }

        Boolean? _Baja;
        public Boolean? Baja { get { return _Baja; } set { _Baja = value; } }

        Int32 _Filtro_PersonaId;
        public Int32 Filtro_PersonaId { get { return _Filtro_PersonaId; } set { _Filtro_PersonaId = value; } }
    }
}
