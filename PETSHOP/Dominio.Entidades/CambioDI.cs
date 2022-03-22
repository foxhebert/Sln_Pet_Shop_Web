using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class CambioDI
    {
        [DataMember] public string strAbreviatura { get; set; }
        [DataMember] public string strNumDocAnt { get; set; }
        [DataMember] public string strNumDocNew { get; set; }
        [DataMember] public string strNomCompleto { get; set; }
        [DataMember] public string strNomUsuarReg { get; set; }
        [DataMember] public string dttFeRegistro { get; set; }
        [DataMember] public string strUniOrg { get; set; }
    }
}
