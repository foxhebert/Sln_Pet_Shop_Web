using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Dominio.Entidades
{
    public class CargoData
    {
        [DataMember] public int intIdCargo { get; set; }
        [DataMember] public string strCoCargo { get; set; }
        [DataMember] public string strDesCargo { get; set; }
        [DataMember] public int intIdUniOrg { get; set; }
        [DataMember]
        public string strCargoCampo1 { get; set; }
        [DataMember]
        public string strCargoCampo2 { get; set; }
        [DataMember]
        public string strCargoCampo3 { get; set; }
        [DataMember]
        public string strCargoCampo4 { get; set; }
        [DataMember]
        public string strCargoCampo5 { get; set; }
        [DataMember]
        public Estado FlActivo { get; set; }
        [DataMember]
        public string strDescripcion { get; set; }
        [DataMember]
        public string strNomJerOrg { get; set; }
        [DataMember]
        public bool bitFlActivo { get; set; }

        [DataMember]
        public bool bitFlEliminado { get; set; }
        [DataMember]
        public int intIdUsuarReg { get; set; }
        [DataMember]
        public DateTime? dttFeRegistro { get; set; }
        [DataMember]
        public int intIdUsuarModif { get; set; }
        [DataMember]
        public DateTime? dttFeModif { get; set; }
    }
}
