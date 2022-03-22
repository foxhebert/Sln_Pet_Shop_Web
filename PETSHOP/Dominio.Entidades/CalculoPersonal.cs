using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class CalculoPersonal
    {
        [DataMember] public int intIdPersonal { get; set; }
        [DataMember] public string strNomCompleto { get; set; }
        [DataMember] public string strNumDoc { get; set; }
        [DataMember] public string strCoPersonal { get; set; }
        [DataMember] public string strDesPlani { get; set; }
        [DataMember] public string strDescripcion { get; set; }
        [DataMember] public string strDeTipo { get; set; }
        [DataMember] public string dttFecAdmin { get; set; }
        [DataMember] public string dttFecCese { get; set; }
        [DataMember] public string strDesGrupoLiq { get; set; }
        [DataMember] public string strFotocheck { get; set; }
        [DataMember] public string intDiasTrabajados { get; set; }
        [DataMember] public string intDiasFaltas { get; set; }
        [DataMember] public string intHorasAdicionales { get; set; }
        [DataMember] public string intFeriados { get; set; }
        [DataMember] public string intHorasFuera { get; set; }
        [DataMember] public string intTardanza { get; set; }
        [DataMember] public string intIdPeriodo { get; set; }
        [DataMember] public string strNoUsuar { get; set; }
        [DataMember] public string dttFeRegistro { get; set; }
        [DataMember] public int intTipo { get; set; }
    }
}
