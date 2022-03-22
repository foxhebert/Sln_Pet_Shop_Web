using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.Sistema
{
    [DataContract]
    public class TSConfi
    {
        [DataMember] public int intIdConfi { get; set; }
        [DataMember] public string strCoConfi { get; set; }
        [DataMember] public string strDesConfi { get; set; }
        [DataMember] public string strValorConfi { get; set; }
        [DataMember] public int intIdSoft { get; set; }
        [DataMember] public string strPosibValor { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public DateTime? dttFeRegistro { get; set; }
        [DataMember] public string tipoControl { get; set; }
    }
}
