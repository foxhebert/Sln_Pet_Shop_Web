using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
    [DataContract]
    public class TGPERCORRDET
    {
        [DataMember] public int intIdPerCorr { get; set; }
        [DataMember] public int intIdPersonal { get; set; }
        [DataMember] public string strCorreo { get; set; }
        [DataMember] public bool bitFlPrincipal { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public string dttFeRegistro { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public string dttFeModif { get; set; }
    }
}
