using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TGJOR_BON_DET
    {
       [DataMember] public int intIdJorBonDet { get; set; }

       [DataMember] public int intIdConcepto  { get; set; }

       [DataMember] public int intIdJornada   { get; set; }

       [DataMember] public int intIdUniOrg { get; set; }
       [DataMember] public DateTime? dttFecAsig { get; set; }
       [DataMember] public  bool  bitFlEliminado { get; set; }
       [DataMember] public  int intIdUsuarReg { get; set; }
       [DataMember] public DateTime? dttFeRegistro { get; set; }
       [DataMember] public  int intIdUsuarModif { get; set; }
       [DataMember] public DateTime?  dttFeModif { get; set; }


    }
}
