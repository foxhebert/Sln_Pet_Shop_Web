using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class RstaConexion
    {
        [DataMember]
        public string estado { get; set; }
        [DataMember]
        public string mensaje { get; set; }
    }
}
