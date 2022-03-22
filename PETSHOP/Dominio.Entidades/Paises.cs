using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class Paises
    {
        [DataMember] public int IntIdPais { get; set; }
        [DataMember] public string strCoPais { get; set; }
        [DataMember] public string strDesPais { get; set; }
        [DataMember] public string strAbreviatura { get; set; }
        [DataMember] public int intTipoContinente { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int IntIdUsuarReg { get; set; }
        [DataMember] public DateTime dttFeRegistro { get; set; }
        [DataMember] public int IntIdUsuarModif { get; set; }
        [DataMember] public DateTime dttFeModif { get; set; }
    }
}
