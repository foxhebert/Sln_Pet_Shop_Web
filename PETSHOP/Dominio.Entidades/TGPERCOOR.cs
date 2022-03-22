using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TGPERCOOR
    {
        [DataMember] public int intIdPerCoord { get; set; }
        [DataMember] public int intIdPersonal { get; set; }
        [DataMember] public int intIdSoftw { get; set; }
        [DataMember] public string strCoord { get; set; }
        [DataMember] public string strDireccionCoord { get; set; }
        [DataMember] public DateTime dttFecAsig { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public bool bitFlGeoArea { get; set; }
        [DataMember] public int intIdGeoArea { get; set; }

    }
}
