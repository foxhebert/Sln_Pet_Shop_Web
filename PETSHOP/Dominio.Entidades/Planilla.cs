using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Planilla
    {

        [DataMember] public int intIdPlanilla { get; set; }
        [DataMember] public string strCoPlani { get; set; }
        [DataMember] public string strDesPlani { get; set; }
        [DataMember] public int intIdUniOrg { get; set; }
        [DataMember] public string strPlaniCampo1 { get; set; }
        [DataMember] public string strPlaniCampo2 { get; set; }
        [DataMember] public string strPlaniCampo3 { get; set; }
        [DataMember] public string strPlaniCampo4 { get; set; }
        [DataMember] public string strPlaniCampo5 { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public bool bitFlPrincipal { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public DateTime? dttFeRegistro { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }
        [DataMember] public string strDescripcion { get; set; }
        [DataMember] public string strNomJerOrg { get; set; }
        [DataMember] public Estado FlActivo { get; set; }



    }
}
