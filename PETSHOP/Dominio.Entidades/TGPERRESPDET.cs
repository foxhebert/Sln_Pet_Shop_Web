using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
    [DataContract]
    public class TGPERRESPDET
    {
        [DataMember] public int intIdPerRespDet { get; set; }
        [DataMember] public int intIdPersonal { get; set; }
        [DataMember] public int intIdPerResp { get; set; }
        [DataMember] public int intIdTipoResp { get; set; }
        [DataMember] public bool bitVigente { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public string dttFeRegistro { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public string dttFeModif { get; set; }
        [DataMember] public string strResponsable { get; set; }
    }
}
