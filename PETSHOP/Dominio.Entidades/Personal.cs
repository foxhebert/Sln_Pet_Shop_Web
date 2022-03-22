using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class Personal
    {
        [DataMember] public int intIdPersonal { get; set; }
        [DataMember] public string strCoPersonal { get; set; }
        [DataMember] public string strNumRegis { get; set; }
        [DataMember] public string strFotocheck { get; set; }
        [DataMember] public int intIdTipDoc { get; set; }
        [DataMember] public string strNumDoc { get; set; }
        [DataMember] public string strNombres { get; set; }
        [DataMember] public string strApePaterno { get; set; }
        [DataMember] public string strApeMaterno { get; set; }
        [DataMember] public string dttFecNacim { get; set; }
        [DataMember] public bool bitflSexo { get; set; }
        [DataMember] public int intIdTipoVia { get; set; }
        [DataMember] public string strDireccion { get; set; }
        [DataMember] public int intIdUbigeo { get; set; }
        [DataMember] public string imgFoto { get; set; }
        [DataMember] public int intIdUniOrg { get; set; }
        [DataMember] public int intIdPlanilla { get; set; }
        [DataMember] public int intIdCargo { get; set; }
        [DataMember] public int intIdCateg { get; set; }
        [DataMember] public int intIdTiPers { get; set; }
        [DataMember] public int intIdGrupo { get; set; }
        [DataMember] public int intIdCCosto { get; set; }
        [DataMember] public int intIdTipFisc { get; set; }
        [DataMember] public int intIdTipoResp { get; set; }
        [DataMember] public bool bitContratoInd { get; set; }
        [DataMember] public string dttFecAdmin { get; set; }
        [DataMember] public string dttFecCese { get; set; }
        [DataMember] public int intIdMotiCese { get; set; }
        [DataMember] public int intIdGrupoLiq { get; set; }
        [DataMember] public bool bitFlSubsidio { get; set; }
        [DataMember] public bool bitFlLinCred { get; set; }
        [DataMember] public string strPersoCampo1 { get; set; }
        [DataMember] public string strPersoCampo2 { get; set; }
        [DataMember] public string strPersoCampo3 { get; set; }
        [DataMember] public string strPersoCampo4 { get; set; }
        [DataMember] public string strPersoCampo5 { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public string bitEspecifica_DESC { get; set; }
        [DataMember] public int intIdUbigSup { get; set; }
        [DataMember] public string strCodExterior { get; set; }
        [DataMember] public string strCodPensionista { get; set; }
        [DataMember] public string strCodSalud { get; set; }
        [DataMember] public bool bitSubsidioAlimentacion { get; set; }
        [DataMember] public bool bitLineaCredito { get; set; }
        [DataMember] public int intIdReglaNeg { get; set; }
        [DataMember] public int intIdHorario { get; set; }
        [DataMember] public bool bitActivarUsuario { get; set; }
        [DataMember] public int intIdUbiSupReg { get; set; }
        [DataMember] public int intIdUbiReg { get; set; }
        [DataMember] public int intIdUbiSupPais { get; set; }
        [DataMember] public int intIdUbiPais { get; set; }
        [DataMember] public int intIdJerOrg { get; set; }
        [DataMember] public int intIdUniOrgSup { get; set; }
        [DataMember] public int intIdLocal { get; set; }
        //Cambio Giancarlo 04/08/2020
        [DataMember] public string strCabe { get; set; }
        [DataMember] public string strDeta { get; set; }
        [DataMember] public string strDescripcion { get; set; }
        [DataMember] public string strDesCargo { get; set; }
        [DataMember] public string strDirUbi { get; set; }
        [DataMember] public string strDir { get; set; }
        [DataMember] public bool bitPerfilAdmin { get; set; }
        [DataMember] public int intIdPerfil { get; set; }
        [DataMember] public string strTipoDoc { get; set; }
        [DataMember] public bool bitFlfotomovil { get; set; }
    }
}
