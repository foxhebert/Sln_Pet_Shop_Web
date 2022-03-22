using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
    [DataContract]
    public class CombosGlobal
    {
        [DataMember] public int intId { get; set; }
        [DataMember] public string strCodigo { get; set; }
        [DataMember] public string strDescripcion { get; set; }
        [DataMember] public string strAbreviatura { get; set; }
    }
}
