using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Reporte
    {
        [DataMember] public int intIdPersonal { get; set; }
        [DataMember] public string strFotocheck { get; set; }
        [DataMember] public string strNomCompleto { get; set; }
        [DataMember] public string strNumDoc { get; set; }
        [DataMember] public string strCoReg { get; set; }
        [DataMember] public string strDesPlani { get; set; }
        [DataMember] public string strDesUniOrg { get; set; }
        [DataMember] public string strDesFis { get; set; }
        [DataMember] public string strDesGrupoLiq { get; set; }
        [DataMember] public string dttFecCese { get; set; }
    }
}
