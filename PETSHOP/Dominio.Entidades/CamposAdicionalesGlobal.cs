using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
   public class CamposAdicionalesGlobal
    {
        [DataMember] public int IntIdCampAdic { get; set; }
        [DataMember] public string strTablaEntid { get; set; }
        [DataMember] public string intIdEntid { get; set; }
        [DataMember] public string IntIdJerOrg { get; set; }
        [DataMember] public string strNoEntidad { get; set; }
        [DataMember] public string strNomCampo { get; set; }
        [DataMember] public int IntIdCampoUO { get; set; }
        [DataMember] public string strTitulo { get; set; }
        [DataMember] public string strTituloAnterior { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int IntIdUsuarReg { get; set; }
        [DataMember] public DateTime? dttFeRegistro { get; set; }
        [DataMember] public int IntIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }
    }
}
