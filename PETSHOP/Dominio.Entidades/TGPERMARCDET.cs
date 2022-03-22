using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
    [DataContract] 
    public class TGPERMARCDET
    {
        [DataMember] public int intIdPerMarc { get; set; }
        [DataMember] public int intIdPersonal { get; set; }
        [DataMember] public int intIdSoft { get; set; }
        [DataMember] public int intIdMarcador { get; set; }
        [DataMember] public string dttFecAsig { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public string dttFeRegistro { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public string dttFeModif { get; set; }
        [DataMember] public string strDesMarcador { get; set; }
    }
}
