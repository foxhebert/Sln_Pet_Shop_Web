using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TipoPerson
    {

        [DataMember] public int IntIdTiPers { get; set; }
        [DataMember] public string strCoTiPers { get; set; }
        [DataMember] public string strDesTiPers { get; set; }
        [DataMember] public int IntIdUniOrg { get; set; }
        [DataMember] public string strTiPersCampo1 { get; set; }
        [DataMember] public string strTiPersCampo2 { get; set; }
        [DataMember] public string strTiPersCampo3 { get; set; }
        [DataMember] public string strTiPersCampo4 { get; set; }
        [DataMember] public string strTiPersCampo5 { get; set; }
        [DataMember] public string strDescripcion { get; set; }
        [DataMember] public string strNomJerOrg { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public Estado FlActivo { get; set; }
        [DataMember] public int IntIdUsuarReg { get; set; }
        [DataMember] public DateTime? dttFeRegistro { get; set; }
        [DataMember] public int IntIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }
    }
}
