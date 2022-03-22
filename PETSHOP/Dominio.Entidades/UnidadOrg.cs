using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class UnidadOrg
    {
        [DataMember] public int intIdUniOrg { get; set; }
        [DataMember] public int intIdJerOrg { get; set; }
        [DataMember] public string strCodigo { get; set; }
        [DataMember] public string strDescripcion { get; set; }
        [DataMember] public int intIdUniOrgSup { get; set; }
        [DataMember] public int intIdPerResp { get; set; }
        [DataMember] public int intIdRepLeg { get; set; }
        [DataMember] public int intIdUbigeo { get; set; }
        [DataMember] public string strRuc { get; set; }
        [DataMember] public int intidTipoVia { get; set; }
        [DataMember] public string strDirFiscal { get; set; }
        [DataMember]  public byte[] imgLogo { get; set; } 
        [DataMember]  public  string strDirLogo { get; set; } 
        [DataMember] public string strUOCampo1 { get; set; }
        [DataMember] public string strUOCampo2 { get; set; }
        [DataMember] public string strUOCampo3 { get; set; }
        [DataMember] public string strUOCampo4 { get; set; }
        [DataMember] public string strUOCampo5 { get; set; }
        [DataMember] public Estado FlActivo { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public bool bitFlPrincipal { get; set; }
        [DataMember] public string strNomJerOrg { get; set; }
        //adicionales de agregado
        [DataMember] public string strDescripcionSup { get; set; }
        /////////////
        ///////
        ///

        [DataMember] public int intextra1 { get; set; }
        [DataMember] public int intextra2 { get; set; }
        [DataMember] public int intextra3 { get; set; }
        [DataMember] public string STRextra1 { get; set; }
        [DataMember] public string STRextra2 { get; set; }
        [DataMember] public string STRextra3 { get; set; }
        [DataMember] public string STRextra4 { get; set; }



    }
}
