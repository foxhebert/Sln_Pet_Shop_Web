using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Categoria
    {
        [DataMember] public int intIdCateg { get; set; }
        [DataMember] public string strCoCateg { get; set; }
        [DataMember] public string strDesCateg { get; set; }
        [DataMember] public int intIdUniOrg { get; set; }
        [DataMember] public string strCateCampo1 { get; set; }
        [DataMember] public string strCateCampo2 { get; set; }
        [DataMember] public string strCateCampo3 { get; set; }
        [DataMember] public string strCateCampo4 { get; set; }
        [DataMember] public string strCateCampo5 { get; set; }
        [DataMember] public string strDescripcion { get; set; }
        [DataMember] public string strNomJerOrg { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public Estado FlActivo { get; set; }
        [DataMember] public DateTime? dttFeRegistro { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }

    }
}
