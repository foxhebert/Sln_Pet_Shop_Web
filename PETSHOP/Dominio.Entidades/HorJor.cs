using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class HorJor
    {
        [DataMember] public int intIdHorJorDet { get; set; }
        [DataMember] public int intIdHorario { get; set; }
        [DataMember] public int intIdJornada { get; set; }
        [DataMember] public string strCodJornada { get; set; }
        [DataMember] public int intNumDiaIni { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public int intIdIntervalo { get; set; }
        [DataMember] public DateTime? dttFeRegistro { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public string strDscJornada { get; set; }
        [DataMember] public string timeHoraIni { get; set; }
        [DataMember] public string timeHoraFin { get; set; }
        [DataMember] public string strColor { get; set; }
        [DataMember] public string strLinea1 { get; set; }
        [DataMember] public string strLinea2 { get; set; }
        [DataMember] public string strLinea3 { get; set; }
        [DataMember] public string strLinea4 { get; set; }
        [DataMember] public string strLinea5 { get; set; }
        [DataMember] public string strLinea6 { get; set; }
        [DataMember] public string strLinea7 { get; set; }



    }
}
