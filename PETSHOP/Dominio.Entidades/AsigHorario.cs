using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class AsigHorario
    {
        [DataMember] public int intIdPerHorario { get; set; }
        [DataMember] public string strCoPersonal { get; set; }
        [DataMember] public string strNombres { get; set; }
        [DataMember] public string strNumDoc { get; set; }
        [DataMember] public string strDeHorario { get; set; }
        [DataMember] public string strDesEmp { get; set; }
        [DataMember] public string strEstado { get; set; }
        [DataMember] public string strFotoCheck { get; set; }


        ////PARA EL DETALLE VER
        [DataMember] public string strDesRegNeg { get; set; }
        [DataMember] public string strCoHorario { get; set; }
        [DataMember] public string strDescHorario { get; set; }
        [DataMember] public string dttFechAsig { get; set; }
        [DataMember] public int intIdHorario { get; set; }



    }
}