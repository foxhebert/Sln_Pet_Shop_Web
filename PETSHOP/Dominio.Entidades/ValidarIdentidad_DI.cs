using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class ValidarIdentidad_DI
    {
        [DataMember] public int intIdPersonal{ get; set; }
        [DataMember] public string strApellidos { get; set; }
        [DataMember] public string strNombres { get; set; }
        [DataMember] public string strCoPersonal { get; set; }
        [DataMember] public string strNumRegis { get; set; }
        [DataMember] public string strFotocheck { get; set; }
        [DataMember] public string strUniOrg { get; set; }
        [DataMember] public string dttFecNacim { get; set; }
    }
}
