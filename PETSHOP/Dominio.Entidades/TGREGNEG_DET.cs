using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TGREGNEG_DET
    {

        [DataMember] public int intIdRegNegDet { get; set; }
        [DataMember] public int intIdReglaNeg { get; set; }
        [DataMember] public string strCoReglaDet { get; set; }
        [DataMember] public string strDesReglaDet { get; set; }
        [DataMember] public string strValorRegla { get; set; }
        [DataMember] public string strPosibValor { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public string strEstadoActivo { get; set; }

    }
}
