using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class RstaListConceptos
    {
        [DataMember]
        public int intIdPerConcepto { get; set; }
        [DataMember]
        public string strEmpleado { get; set; }
        [DataMember]
        public string strEmpleadoLista { get; set; }
        [DataMember]
        public string rangoHora { get; set; }
        [DataMember]
        public string strCoConcepto { get; set; }
        [DataMember]
        public string strDesConcepto { get; set; }
        [DataMember]
        public string dttFecha { get; set; }
        [DataMember]
        public string strDeTipo { get; set; }
        [DataMember]
        public int intIdConcepto { get; set; }
    }
}
