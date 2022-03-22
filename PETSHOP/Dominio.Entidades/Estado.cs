using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class Estado
    {
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public string strEstadoActivo { get; set; }
    }
}
