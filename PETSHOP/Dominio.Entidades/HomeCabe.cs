using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class HomeCabe
    {
        [DataMember] public string icon { get; set; }
        [DataMember] public string titulo { get; set; }
        [DataMember] public string valor { get; set; }
        [DataMember] public string pie { get; set; }
    }
}
