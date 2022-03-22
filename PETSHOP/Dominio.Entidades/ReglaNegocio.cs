using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class ReglaNegocio
    {

        [DataMember] public int intIdReglaNeg { get; set; }
        [DataMember] public string strCoRegNeg { get; set; }
        [DataMember] public string strDesRegNeg { get; set; }
        [DataMember] public int intIdSoft { get; set; }
        [DataMember] public int IntIdUniOrg { get; set; }
        [DataMember] public bool bitFlInterna { get; set; }
        [DataMember] public string strRegNegCampo1 { get; set; }
        [DataMember] public string strRegNegCampo2 { get; set; }
        [DataMember] public string strRegNegCampo3 { get; set; }
        [DataMember] public string strRegNegCampo4 { get; set; }
        [DataMember] public string strRegNegCampo5 { get; set; }
        [DataMember] public string strDescUO { get; set; }
        [DataMember] public string strJerOrg { get; set; }
        [DataMember] public string strEstado { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public bool bitFlPrincipal { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public DateTime? dttFeRegistro { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }


        [DataMember] public int intextra1 { get; set; }
        [DataMember] public int intextra2 { get; set; }

        //Añadido para Regla de Negocio Comedor hg_10.02.21
        [DataMember] public string strTipoConsu { get; set; }
        [DataMember] public string strContSub { get; set; }
        [DataMember] public string strDesEstado { get; set; }

    }
}
