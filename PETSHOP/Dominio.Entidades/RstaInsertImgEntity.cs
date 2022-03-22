using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class RstaInsertImgEntity
    {
        [DataMember]
        public string strMensaje { get; set; }
        [DataMember]
        public int intEstado { get; set; }
    }
}
