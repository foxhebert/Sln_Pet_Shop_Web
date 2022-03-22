using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class CCosto
    {
        [DataMember] public int IntIdCCosto { get; set; }
        [DataMember] public string strCoCCosto { get; set; }
        [DataMember] public string strDesCCosto { get; set; }
        [DataMember] public int intIdTipFisc { get; set; }
        [DataMember] public int IntIdUniOrg { get; set; }
        [DataMember] public string strCeCoCampo1 { get; set; }
        [DataMember] public string strCeCoCampo2 { get; set; }
        [DataMember] public string strCeCoCampo3 { get; set; }
        [DataMember] public string strCeCoCampo4 { get; set; }
        [DataMember] public string strCeCoCampo5 { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int IntIdUsuarReg { get; set; }
        [DataMember] public DateTime? dttFeRegistro { get; set; }
        [DataMember] public int IntIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }
        [DataMember] public string strDescripcion { get; set; }
        [DataMember] public string strNomJerOrg { get; set; }
        [DataMember] public Estado FlActivo { get; set; }

    }
}
