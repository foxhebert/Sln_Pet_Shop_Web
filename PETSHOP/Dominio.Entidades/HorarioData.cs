using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class HorarioData
    {

        [DataMember] public int intIdHorario { get; set; }
        [DataMember] public string strCoHorario { get; set; }
        [DataMember] public string strDeHorario { get; set; }

        [DataMember] public string strExtra1 { get; set; }
        [DataMember] public string strExtra2 { get; set; }
        [DataMember] public string strExtra3 { get; set; }
        [DataMember] public string strExtra4 { get; set; }



    }
}
