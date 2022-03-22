using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class JerarquiaOrg
    {
        [DataMember] public int IntIdJerOrg { get; set; }
        [DataMember] public string strCoIntJO { get; set; }
        [DataMember] public string strCoJerOrg { get; set; }
        [DataMember] public string strNomJerOrg { get; set; }
        [DataMember] public String intNivelJer { get; set; }
        [DataMember] public string strCoJerPadre { get; set; }
        [DataMember] public string strJerarCampo1 { get; set; }
        [DataMember] public string strJerarCampo2 { get; set; }
        [DataMember] public string strJerarCampo3 { get; set; }
        [DataMember] public string strJerarCampo4 { get; set; }
        [DataMember] public string strJerarCampo5 { get; set; }
        [DataMember] public Estado FlActivo { get; set; }   
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int IntIdUsuarReg { get; set; }
        [DataMember] public DateTime? dttFeRegistro { get; set; }
        [DataMember] public int IntIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }

        //Adicionales
        [DataMember] public string strNomJerPadre { get; set; }

    }
}
