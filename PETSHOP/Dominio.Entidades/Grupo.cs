using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Grupo
    {
        
        [DataMember] public int intIdGrupo { get; set; }
        [DataMember] public string strCoGrupo { get; set; }
        [DataMember] public string strDesGrupo { get; set; }
        [DataMember] public int intIdUniOrg { get; set; }
        [DataMember] public string strGrupoCampo1 { get; set; }
        [DataMember] public string strGrupoCampo2 { get; set; }
        [DataMember] public string strGrupoCampo3 { get; set; }
        [DataMember] public string strGrupoCampo4 { get; set; }
        [DataMember] public string strGrupoCampo5 { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public DateTime? dttFeRegistro { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }
        [DataMember] public string strDescripcion { get; set; }
        [DataMember] public string strNomJerOrg { get; set; }
        [DataMember] public Estado FlActivo { get; set; }

        

    }
}
