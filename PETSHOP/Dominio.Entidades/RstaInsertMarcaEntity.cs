using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class RstaInsertMarcaEntity
    {
        [DataMember]
        public string strMensaje { get; set; }
        [DataMember]
        public int iEstado { get; set; }
        [DataMember]
        public int idAsistencia { get; set; }
    }
}
