using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class Ubigeo
    {
        [DataMember] public int intIdUbigeo { get; set; }
        [DataMember] public string strCoUbigeo { get; set; }
        [DataMember] public string strDesUbigeo { get; set; }
        [DataMember] public int intIdTipUbig { get; set; }
        [DataMember] public int intIdUbiSup { get; set; }
        [DataMember] public int intIdPais { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public DateTime dttFeRegistro { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime dttFeModif { get; set; }
    }
}
