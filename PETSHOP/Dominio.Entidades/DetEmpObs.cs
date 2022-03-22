using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Dominio.Entidades
{
    public class DetEmpObs
    {
        [DataMember] public int intCodigo { get; set; }
        [DataMember] public string strCodEmpleado { get; set; }
        [DataMember] public string strNomCompleto { get; set; }
        [DataMember] public string strObservacion { get; set; }
    }
}
