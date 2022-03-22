using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class RstaListaCoordEntity
    {
        [DataMember]public int idPersonal { get; set; }

        [DataMember]
        public int bitFlGeoArea { get; set; }

        [DataMember]
        public decimal MINI { get; set; }

        [DataMember]
        public decimal MAXI { get; set; }
    }
}
