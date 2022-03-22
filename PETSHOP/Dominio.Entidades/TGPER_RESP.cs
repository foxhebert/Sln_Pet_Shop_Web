using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TGPER_RESP
    {
        [DataMember] public int intIdPerRespDet { get; set; }
        [DataMember] public int intIdPersonal { get; set; }
        [DataMember] public string strCoPersonal { get; set; }
        [DataMember] public string strNombresComp { get; set; }
        [DataMember] public int intIdTipoResp { get; set; } 
        [DataMember] public string strDeTipo { get; set; }
        [DataMember] public string strDesCargo { get; set; }
    }
}

