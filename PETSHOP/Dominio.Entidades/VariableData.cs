using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class VariableData
    {

        [DataMember] public int intIdConcepto { get; set; }
        [DataMember] public string strCoConcepto { get; set; }
        [DataMember] public string strDesConcepto { get; set; }       
        [DataMember] public string strActivo { get; set; }
        [DataMember] public string strDeTipotipo { get; set; }
        [DataMember] public string strDeTipoum { get; set; }

    }
}