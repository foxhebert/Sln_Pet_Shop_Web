using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class GrupoLiquidacion
    {
        [DataMember] public int intIdGrupoLiq { get; set; }
        [DataMember] public string strCoGrupoLiq { get; set; }
        [DataMember] public string strDesGrupoLiq { get; set; }
        [DataMember] public int intIdPeriodo { get; set; }
        [DataMember] public string strGrupoLiqCampo1 { get; set; }
        [DataMember] public string strGrupoLiqCampo2 { get; set; }
        [DataMember] public string strGrupoLiqCampo3 { get; set; }
        [DataMember] public string strGrupoLiqCampo4 { get; set; }
        [DataMember] public string strGrupoLiqCampo5 { get; set; }
        [DataMember] public bool bitFlCerrado { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public DateTime? dttFeRegistro { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }

        [DataMember] public int intIdPlanilla { get; set; }
        [DataMember] public int intIdUniOrg { get; set; }
        [DataMember] public int intIdJerOrg { get; set; }

        [DataMember] public string strDesPeriodo { get; set; }
        [DataMember] public string strEstadoActivo { get; set; }

    }
}
