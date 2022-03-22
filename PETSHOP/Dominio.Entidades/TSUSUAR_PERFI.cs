using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TSUSUAR_PERFI
    {
        [DataMember] public int intIdUsPerf { get; set; }
        [DataMember] public int intIdUsuar { get; set; }
        [DataMember] public int intIdPerfil { get; set; }
        [DataMember] public bool bitFlPrincipal { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
    }
}
