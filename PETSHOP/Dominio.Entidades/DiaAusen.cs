using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class DiaAusen
    {
        [DataMember] public int intIdConcepto { get; set; }
        [DataMember] public string strCoConcepto { get; set; }
        [DataMember] public string strDesConcepto{ get; set; }
        [DataMember] public int intTotalDias { get; set; }
    }
}
