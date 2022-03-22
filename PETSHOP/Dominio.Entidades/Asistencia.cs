using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Asistencia
    {
        [DataMember] public long intIdAsistencia { get; set; }
        [DataMember] public int intIdPersonal { get; set; }
        [DataMember] public int strFotoCheck { get; set; }
        [DataMember] public string dttFecha { get; set; }
        [DataMember] public string dttFechaHora { get; set; }
        [DataMember] public int intTipoIngreso { get; set; }
        [DataMember] public int tinIdTMarcacion { get; set; }
        [DataMember] public int intIdMarcador { get; set; }
        [DataMember] public int intIdMotivo { get; set; }
        [DataMember] public bool biFlMarcaForzada { get; set; }
        [DataMember] public string strIncidencia { get; set; }
        [DataMember] public int intIdGrupo { get; set; }
        [DataMember] public int intIdCultivo { get; set; }
        [DataMember] public int intIdActividad { get; set; }
        [DataMember] public int intIdSubActividad { get; set; }
        [DataMember] public bool bitFlFicticio { get; set; }
        [DataMember] public string strActualizado { get; set; }
        [DataMember] public string strAsistCampo1 { get; set; }
        [DataMember] public string strAsistCampo2 { get; set; }
        [DataMember] public string strAsistCampo3 { get; set; }
        [DataMember] public string strAsistCampo4 { get; set; }
        [DataMember] public string strAsistCampo5 { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public DateTime? dttFeRegistro { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }
        [DataMember] public string strMarcador { get; set; }
        [DataMember] public string strTipoMarca { get; set; }

        [DataMember] public bool bitFlRepetido { get; set; }
        [DataMember] public string strRepetido { get; set; }
        [DataMember] public int intIdTipoMarca { get; set; }
        [DataMember] public int intDiaSgt { get; set; }
        [DataMember] public int intModomarca { get; set; }
        [DataMember] public string strRutaFoto { get; set; }
        [DataMember] public string strCodTipoMarca { get; set; }
        [DataMember] public string strDireccion_marca { get; set; }
        
    }
}
