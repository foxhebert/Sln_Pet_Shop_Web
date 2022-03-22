using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dominio.Entidades
{
    [DataContract]
    public class Entidade
    {
        [DataMember] public int intIdEntid { get; set; }
        [DataMember] public int intIdSoft { get; set; }
        [DataMember] public string strNomEntid { get; set; }
        [DataMember] public string strDesEntid { get; set; }
        [DataMember] public string strIdCampo { get; set; }
        [DataMember] public string strCoCampo { get; set; }
        [DataMember] public string strDesCampo { get; set; }
        [DataMember] public string strTablaEntid { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public string strCampAdic { get; set; }

    }
}
