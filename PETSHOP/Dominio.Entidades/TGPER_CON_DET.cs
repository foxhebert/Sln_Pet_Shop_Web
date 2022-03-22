using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TGPER_CON_DET
    {
        [DataMember] public int intIdPersonal { get; set; }
        [DataMember] public int intIdConcepto { get; set; }
        [DataMember] public string strCoConcepto { get; set; }
        [DataMember] public string strDesConcepto { get; set; }
        [DataMember] public string strDeTipo { get; set; }
        [DataMember] public string strCoTipo { get; set; }
        [DataMember] public int intTotalDias { get; set; }
        [DataMember] public decimal intTotalHoras { get; set; }
        [DataMember] public int intTope { get; set; }
    }
}
