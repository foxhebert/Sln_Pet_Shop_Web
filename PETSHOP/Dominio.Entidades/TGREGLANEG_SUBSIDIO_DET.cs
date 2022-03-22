using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TGREGLANEG_SUBSIDIO_DET
    {


        [DataMember] public int IntIdReglaNegSubsDet { get; set; }
        [DataMember] public int IntIdReglaNeg { get; set; }
        [DataMember] public int IntIdEmp { get; set; }
        [DataMember] public decimal nmPorcentaje { get; set; }
        [DataMember] public int intidtipoMenu { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public DateTime? dttFeReg { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }

        //CON SUBSIDIO HG 26.02.21 12:32PM
        //[DataMember] public int IntIdReglaNegSubsDet { get; set; }
        //[DataMember] public int IntIdReglaNeg { get; set; }
        [DataMember] public string strDeEmpresa { get; set; }
        //[DataMember] public string strDesEmp { get; set; }
        //[DataMember] public int intidtipoMenu { get; set; }
        [DataMember] public string strDeTipoMenu { get; set; }
        //[DataMember] public int nmPorcentaje { get; set; }

        [DataMember] public int    intIdTipServ  { get; set; }
        [DataMember] public string strDeTipoServ { get; set; }


    }
}
