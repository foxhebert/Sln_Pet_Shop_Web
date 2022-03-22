using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Runtime.Serialization;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BODESOFT.Models
{
    public class TB_LISTADO
    {

        [DataMember] public int IntIdEmp { get; set; }
        [DataMember] public string strCoEmp { get; set; }
        [DataMember] public string strDesEmp { get; set; }
        [DataMember] public string strRuc { get; set; }
        [DataMember] public string strDirFiscal { get; set; }
        [DataMember] public string imgLogo { get; set; }
        [DataMember] public int intTipoEmp { get; set; }
        [DataMember] public string strTipoEmp { get; set; }
        [DataMember] public string strEmpresaCampo1 { get; set; }
        [DataMember] public string strEmpresaCampo2 { get; set; }
        [DataMember] public string strEmpresaCampo3 { get; set; }
        [DataMember] public string strEmpresaCampo4 { get; set; }
        [DataMember] public string strEmpresaCampo5 { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public string strDesEstado { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public DateTime? dttFeReg { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }


    }
}

