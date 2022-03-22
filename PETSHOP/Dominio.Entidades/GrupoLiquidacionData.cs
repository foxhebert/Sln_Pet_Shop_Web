using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class GrupoLiquidacionData
    {
        [DataMember] public int intIdGrupoLiq { get; set; }
        [DataMember] public string strCoGrupoLiq { get; set; }
        [DataMember] public string strDesGrupoLiq { get; set; }
        [DataMember] public string strDesPeriodo { get; set; }
        [DataMember] public string strEstadoActivo { get; set; }
    }
}
