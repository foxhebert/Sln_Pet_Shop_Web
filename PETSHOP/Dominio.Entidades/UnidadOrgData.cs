using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class UnidadOrgData
    {
        [DataMember] public int intIdUniOrg { get; set; }
        [DataMember] public string strCodigo { get; set; }
        [DataMember] public string strDescripcion { get; set; }
        [DataMember] public int intIdUniOrgSup { get; set; }
        [DataMember] public int intIdPerResp { get; set; }
        [DataMember] public int intIdRepLeg { get; set; }
        [DataMember] public int intIdUbigeo { get; set; }
        [DataMember] public string strRuc { get; set; }
        [DataMember] public Estado FlActivo { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public string strNomJerOrg { get; set; }
        [DataMember] public string strDescripcionSup { get; set; }
        [DataMember] public string strDirLogo { get; set; }
    }
}
