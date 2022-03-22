using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
    [DataContract]
    public class RstaInsertConcepto
    {
        [DataMember]
        public string strRespuesta { get; set; }
    }
}
