using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class TGPER_RESERVA
    {
        [DataMember] public string strCoPersonal { get; set; }
        [DataMember] public string strNumRegis   { get; set; }
        [DataMember] public int intIdTipDoc      { get; set; }
        [DataMember] public string strNumDoc     { get; set; }
        [DataMember] public int intIdUsuarReg    { get; set; }
        [DataMember] public DateTime? dttFeRegistro { get; set; }
    }
}
