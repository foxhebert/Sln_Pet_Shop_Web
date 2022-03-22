using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
    [DataContract]
   public class ValidarIdentidad_ENT
    {
        [DataMember] public int intExiste { get; set; }
        [DataMember] public string strCodPersonal { get; set; }
        [DataMember] public string strNumRegist { get; set; }
        [DataMember] public int intTipoDoc { get; set; }
        [DataMember] public string strNumDoc { get; set; }
        [DataMember] public string strObservacion { get; set; }
        [DataMember] public int intIdPersonal { get; set; }
    }
}
