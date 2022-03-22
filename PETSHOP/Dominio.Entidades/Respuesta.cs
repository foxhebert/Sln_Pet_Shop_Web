using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
    [DataContract]
    public class Respuesta
    {
        [DataMember] public string type { get; set; }
        [DataMember] public string message { get; set; }
    }
}
