using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
    [DataContract]
    public class RstaListComboConcepto
    {
        [DataMember]
        public int intIdConcepto { get; set; }
        [DataMember]
        public string strDesConcepto { get; set; }
        [DataMember]
        public string strCoTipo { get; set; }
        [DataMember]
        public int bitFlDescontable { get; set; }
    }
}
