using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class CamposAdicionales
    {
        [DataMember] public int IntIdCampo { get; set; }
        [DataMember] public string strCoCampo { get; set; }
        [DataMember] public string strDesCampo { get; set; }
        [DataMember] public string strNomCampo { get; set; }
        [DataMember] public string strTipoDato { get; set; }
        [DataMember] public int strLongitud { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int IntIdUsuarReg { get; set; }
        [DataMember] public DateTime? dttFeRegistro { get; set; }
        [DataMember] public int IntIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }
    }
}
