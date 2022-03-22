using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class RepLegal
    {
        [DataMember] public int IntIdRepLeg { get; set; }
        [DataMember] public Int16 tinIdTipDoc { get; set; }
        [DataMember] public string strNumDoc { get; set; }
        [DataMember] public string strNombres { get; set; }
        [DataMember] public string strApePaterno { get; set; }
        [DataMember] public string strApeMaterno { get; set; }
        [DataMember] public string strDesCargo { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int IntIdUsuarReg { get; set; }
        [DataMember] public string dttFeRegistro { get; set; }
        [DataMember] public int IntIdUsuarModif { get; set; }
        [DataMember] public DateTime dttFeModif { get; set; }

    }
}
