using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class RstaValidPersonalEntity
    {
        [DataMember]
        public int intEstado { get; set; }
        [DataMember]
        public string strMensaje { get; set; }
        [DataMember]
        public string strNombres { get; set; }
        [DataMember]
        public string strApePaterno { get; set; }
        [DataMember]
        public string strApeMaterno { get; set; }
        [DataMember]
        public string strIdPersonal { get; set; }
        //18012021
        [DataMember]
        public int bitFoto { get; set; }
    }
}
