using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class Cliente
    {

        [DataMember] public int intIdCliente { get; set; }
        [DataMember] public string strCoCliente { get; set; }
        [DataMember] public string strDesCliente { get; set; }
        [DataMember] public string strLPNRaiz { get; set; }
        [DataMember] public int intIdCentroAlm { get; set; }
        [DataMember] public string strClienteCampo1 { get; set; }
        [DataMember] public string strClienteCampo2 { get; set; }
        [DataMember] public string strClienteCampo3 { get; set; }
        [DataMember] public string strClienteCampo4 { get; set; }
        [DataMember] public string strClienteCampo5 { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public Estado FlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public DateTime dttFeReg { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime dttFeModif { get; set; }


        //Adicionales
        [DataMember] public string strDesCentroAlm { get; set; }
        [DataMember] public string strAdicional { get; set; }
    }
}
