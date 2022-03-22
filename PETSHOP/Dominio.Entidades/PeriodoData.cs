using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class PeriodoData
    {
        [DataMember] public int intIdPeriodo { get; set; }
        [DataMember] public string strDesPlani { get; set; }
        [DataMember] public string strCoPeriodo { get; set; }
        [DataMember] public string strDesPeriodo { get; set; }
        [DataMember] public string strMesAnio { get; set; }
        [DataMember] public string strDependencia { get; set; }
        [DataMember] public string strEstadoCerrado { get; set; }
        [DataMember] public string strEstadoActivo { get; set; }
    }
}
