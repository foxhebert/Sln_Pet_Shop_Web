using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;//añadido 02.11.2021
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class Emisor
    {
        [DataMember] public string RUC { get; set; }
        [DataMember] public string DIRECCION { get; set; }
        [DataMember] public string TLF { get; set; }
        [DataMember] public string WSP { get; set; }
        [DataMember] public string EMAIL { get; set; }
        [DataMember] public string LOGO { get; set; }
    }
}
