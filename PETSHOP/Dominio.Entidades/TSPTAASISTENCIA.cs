using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TSPTAASISTENCIA
    {
        [DataMember] public int anio { get; set; }
        [DataMember] public int mes { get; set; }
        [DataMember] public int asistencia { get; set; }
        [DataMember] public int faltas { get; set; }

        [DataMember] public string strTipo { get; set; }

        //PARA GRAFICA BIENES vs TIPO BIENES
        [DataMember] public int intIdTipo { get; set; }
        [DataMember] public string strCodTipo { get; set; }
        [DataMember] public string strDescTipo { get; set; }
        [DataMember] public int coninventario { get; set; }
        [DataMember] public int sininventario { get; set; }

    }
}
