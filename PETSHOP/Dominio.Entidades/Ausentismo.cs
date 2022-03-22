using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Ausentismo
    {
        [DataMember] public int intIdPerConcepto { get; set; }
        [DataMember] public int intIdPersonal { get; set; }
        [DataMember] public int intIdConcepto { get; set; }
        [DataMember] public string dttFecha { get; set; }
        [DataMember] public int intIdSoft { get; set; }
        [DataMember] public int intHoraIni { get; set; }
        [DataMember] public int intHoraFin { get; set; }
        [DataMember] public string timeHoraIni { get; set; } //modificado
        [DataMember] public string timeHoraFin { get; set; } //modificado
        [DataMember] public int tinDiaPertenen { get; set; }
        [DataMember] public string strObservacion { get; set; }
        [DataMember] public bool bitFlCompensable { get; set; } //modificado
                                                                //[DataMember] public int bitFlCompensable { get; set; }
        [DataMember] public bool bitSustentado { get; set; } //modificado

        //[DataMember] public int bitSustentado { get; set; }
        [DataMember] public bool bitEspeciValor { get; set; }    //modificado
        //[DataMember] public int bitEspeciValor { get; set; }
        [DataMember] public string strCITT { get; set; }
        [DataMember] public string strNoInstitucion { get; set; }
        [DataMember] public string strEspecialidad { get; set; }
        [DataMember] public string strNoDoctor { get; set; }
        [DataMember] public string strintTipoUM { get; set; }
        [DataMember] public int IntIdCCosto { get; set; }
        [DataMember] public int intIdGestionVacDet { get; set; }
        [DataMember] public int intIdEstado { get; set; }
        [DataMember] public int intIdActividad { get; set; }
        [DataMember] public int intIdSubActividad { get; set; }
        [DataMember] public int intIdGrupo { get; set; }
        [DataMember] public int intIdUsuarAprob { get; set; }
        [DataMember] public DateTime? dttFeAprobacion { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }
        [DataMember] public int IntIdTipoDoc { get; set; }
        [DataMember] public string strRutaDocumento { get; set; }
        //[DataMember] public int intIdPerConcepto { get; set; }
        ////PARA EL DETALLE VER
        [DataMember] public string strCoConcepto { get; set; }
        [DataMember] public string strDesConcepto { get; set; }
        //[DataMember] public string dttFecha { get; set; }
        [DataMember] public string strDeTipo { get; set; }
        [DataMember] public List<Documento> listDocumentos { get; set; }
        //[DataMember] public int intIdConcepto { get; set; }

        [DataMember] public bool bitDiaSgtIni { get; set; }
        [DataMember] public bool bitDiaSgtFin { get; set; }
    }

}
