using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades

{
    public class CentroAlmacenamiento
    {

        [DataMember] public int intIdCentroAlm { get; set; }
        [DataMember] public string strCoCentroAlm { get; set; }
        [DataMember] public string strDesCentroAlm { get; set; }
        [DataMember] public int intIdEmp { get; set; }
        [DataMember] public string strCentroAlmCampo1 { get; set; }
        [DataMember] public string strCentroAlmCampo2 { get; set; }
        [DataMember] public string strCentroAlmCampo3 { get; set; }
        [DataMember] public string strCentroAlmCampo4 { get; set; }
        [DataMember] public string strCentroAlmCampo5 { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public Estado FlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public DateTime? dttFeReg { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }


        [DataMember] public string strDesEmp { get; set; }
    }
}