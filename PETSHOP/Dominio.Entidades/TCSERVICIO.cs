using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;



namespace Dominio.Entidades
{
    public class TCSERVICIO
    {

        [DataMember] public int intIdServicio { get; set; }
        [DataMember] public string strCoServicio { get; set; }
        [DataMember] public string strDesServicio { get; set; }
        [DataMember] public string strCoExporta { get; set; }
        [DataMember] public int intIdUniOrg { get; set; }
        [DataMember] public int intIdTipServ { get; set; }
        [DataMember] public int intIdTipoMenu { get; set; }
        [DataMember] public decimal monCostoServ { get; set; }
        [DataMember] public int intIdMoneda { get; set; }
        [DataMember] public string strServicioCampo1 { get; set; }
        [DataMember] public string strServicioCampo2 { get; set; }
        [DataMember] public string strServicioCampo3 { get; set; }
        [DataMember] public string strServicioCampo4 { get; set; }
        [DataMember] public string strServicioCampo5 { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public DateTime? dttFeReg { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }

        [DataMember] public string strDesTipServicio { get; set; }
        [DataMember] public string strDesTipMenu { get; set; }
        [DataMember] public string strDesEstado { get; set; }
        [DataMember] public int intClase { get; set; }//añadido 18.03.2021
        [DataMember] public string strDesClase { get; set; }//añadido 18.03.2021
        [DataMember] public int intCategSC { get; set; }//añadido 20.03.2021

        [DataMember] public int intIdJerOrg { get; set; }

    }
}
