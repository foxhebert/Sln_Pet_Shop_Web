using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class RstaListMarcaEntity
    {
        [DataMember]
        public string idpersonal { get; set; }
        [DataMember]
        public string fotocheck { get; set; }
        [DataMember]
        public string tipo_acceso { get; set; }
        [DataMember]
        public string Num_marcador { get; set; }
        [DataMember]
        public string hora { get; set; }
        [DataMember]
        public string fecha { get; set; }
        [DataMember]
        public string personal { get; set; }
        [DataMember]
        public string estado { get; set; }
        [DataMember]
        public string foto { get; set; }
        [DataMember]
        public string fotoConverted { get; set; }
    }
}
