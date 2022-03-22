using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Horario
    {

        [DataMember] public int intIdHorario { get; set; }
        [DataMember] public int intIdSoft { get; set; }
        [DataMember] public string strCoHorario { get; set; }
        [DataMember] public string strDeHorario { get; set; }
        [DataMember] public int intTotalDias { get; set; }
        [DataMember] public int intNumDiaIni { get; set; }
        [DataMember] public int intIdUniOrg { get; set; }
        [DataMember] public string strHorarioCampo1 { get; set; }
        [DataMember] public string strHorarioCampo2 { get; set; }
        [DataMember] public string strHorarioCampo3 { get; set; }
        [DataMember] public string strHorarioCampo4 { get; set; }
        [DataMember] public string strHorarioCampo5 { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public bool bitFlPrincipal { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public DateTime? dttFeRegistro { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }

        [DataMember] public string strExtra1 { get; set; }
        [DataMember] public string strExtra2 { get; set; }
        [DataMember] public string strExtra3 { get; set; }
        [DataMember] public string strExtra4 { get; set; }
        [DataMember] public int intExtra1 { get; set; }
        [DataMember] public int intExtra2 { get; set; }



    }
}
