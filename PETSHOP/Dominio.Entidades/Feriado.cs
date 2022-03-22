using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
   public  class Feriado
    {
        [DataMember] public int IntIdFeriado { get; set; } 
        [DataMember] public string strDeFeriado { get; set; }
        [DataMember] public bool bitRegEspecif { get; set; }
        [DataMember] public string bitRegEspecif_desc { get; set; }
        [DataMember] public string bitRecursiv_desc { get; set; }
        [DataMember] public int intTipoReg { get; set; }
        [DataMember] public int intIdConcepto { get; set; }
        [DataMember] public bool bitRecursiv { get; set; }
        [DataMember] public bool intTipoConcepto { get; set; }
        [DataMember] public int intTipoRec { get; set; }
        [DataMember] public string dttfechaIni { get; set; }
        [DataMember] public int intDuracion { get; set; }
        [DataMember] public bool bitEspecifica { get; set; }
        [DataMember] public int intIdSoft { get; set; }
        [DataMember] public string strFeriaCampo1 { get; set; }
        [DataMember] public string strFeriaCampo2 { get; set; }
        [DataMember] public string strFeriaCampo3 { get; set; }
        [DataMember] public string strFeriaCampo4 { get; set; }
        [DataMember] public string strFeriaCampo5 { get; set; }
        [DataMember] public DateTime? timeHoraIni { get; set; }
        [DataMember] public DateTime? timeHoraFin { get; set; }
        [DataMember] public string timeHoraIni_desc { get; set; }
        [DataMember] public string timeHoraFin_desc { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public string bitFlActivo_desc { get; set; }
        [DataMember] public string CAMPO_CONCAT { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public DateTime? dttFeRegistro { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }
        [DataMember] public string bitEspecifica_DESC { get; set; }



    }
}
