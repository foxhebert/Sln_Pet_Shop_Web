using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class ReporteM
    {
        [DataMember] public int intIdReporte { get; set; }
        [DataMember] public string strCoReporte { get; set; }
        [DataMember] public string strDesReporte { get; set; }
        [DataMember] public string strCoPadre { get; set; }
        [DataMember] public int intOrden { get; set; }
        [DataMember] public string strRpt { get; set; }
        [DataMember] public string strSP { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public DateTime dttFeRegistro { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime dttFeModif { get; set; }
        [DataMember] public List<ReporteM> ListHijos { get; set; }
    }
}
