using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TGFER_UNIORG_DET
    {
        [DataMember] public int intIdFerUniOrg { get; set; }
        [DataMember] public int intIdFeriado { get; set; }
        [DataMember] public int intIdUniOrg { get; set; }
        [DataMember] public int IntIdJerOrg { get; set; }

    }
}
