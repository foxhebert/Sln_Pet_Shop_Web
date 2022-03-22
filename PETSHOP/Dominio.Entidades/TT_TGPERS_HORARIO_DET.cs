using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Dominio.Entidades
{
    public class TT_TGPERS_HORARIO_DET
    {

        [DataMember] public int intIdPerHorario { get; set; }
        [DataMember] public int intIdSoftw { get; set; }
        [DataMember] public int intIdHorario { get; set; }
        [DataMember] public DateTime? dttFecAsig { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int IntIdUsuarReg { get; set; }
        [DataMember] public DateTime? dttFeRegistro { get; set; }


    }
}
