using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class JerCampDet
    {
        [DataMember] public int intIdJerCampo { get; set; }
        [DataMember] public int IntIdJerOrg { get; set; }
        [DataMember] public string strCoIntJO { get; set; }
        [DataMember] public int intIdCampo { get; set; }
        [DataMember] public string strCoCampo { get; set; }
        [DataMember] public bool bitObligatorio { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public DateTime dttFeRegistro { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime dttFeModif { get; set; }
    }
}
