using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Marcador
    {


        [DataMember] public int intIdMarcador { get; set; }
        [DataMember] public int intNumMarcador { get; set; }
        [DataMember] public string strDesMarcador { get; set; }
        [DataMember] public int intTipoMarcad { get; set; }
        [DataMember] public int intTipoFunc { get; set; }
        [DataMember] public bool bitTipoComu { get; set; }
        [DataMember] public string strNumIP { get; set; }
        [DataMember] public string intNumPuerto { get; set; }
        [DataMember] public int intIdSoft { get; set; }
        [DataMember] public int intIdUniOrg { get; set; }
        [DataMember] public string strMarcadCampo1 { get; set; }
        [DataMember] public string strMarcadCampo2 { get; set; }
        [DataMember] public string strMarcadCampo3 { get; set; }
        [DataMember] public string strMarcadCampo4 { get; set; }
        [DataMember] public string strMarcadCampo5 { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public DateTime? dttFeRegistro { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }
        [DataMember] public string strDescripcion { get; set; }
        [DataMember] public string strNomJerOrg { get; set; }
        [DataMember] public Estado FlActivo { get; set; }

        [DataMember] public string NumIPNumPort { get; set; }

}
}
            