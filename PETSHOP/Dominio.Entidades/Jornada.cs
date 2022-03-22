using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Jornada
    {
        [DataMember] public int intIdJornada { get; set; }
        [DataMember] public int intIdSoft { get; set; }
        [DataMember] public string strCodJornada { get; set; }
        [DataMember] public string strDscJornada { get; set; }
        [DataMember] public int intTipoDia { get; set; }
        [DataMember] public int intControlRefri { get; set; }
        [DataMember] public int intColorAlfa { get; set; }
        [DataMember] public int IntColorRojo { get; set; }
        [DataMember] public int IntColorVerde { get; set; }
        [DataMember] public int IntColorAzul { get; set; }
        [DataMember] public int IntIdUniOrg { get; set; }
        [DataMember] public bool bitDiaSig { get; set; }
        [DataMember] public bool bitPertenecDiaSig { get; set; }
        [DataMember] public string strColor { get; set; }
        [DataMember] public string strJornadaCampo1 { get; set; }
        [DataMember] public string strJornadaCampo2 { get; set; }
        [DataMember] public string strJornadaCampo3 { get; set; }
        [DataMember] public string strJornadaCampo4 { get; set; }
        [DataMember] public string strJornadaCampo5 { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public DateTime? dttFeRegistro { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }

        [DataMember] public string timeHoraIni { get; set; }

        [DataMember] public string timeHoraFin { get; set; }
        [DataMember] public string EXtra1 { get; set; }
        [DataMember] public string EXtra2 { get; set; }
        [DataMember] public string EXtra3 { get; set; }
        [DataMember] public string EXtra4 { get; set; }

        //Jornada Comedor
        [DataMember] public string strTipoJornada { get; set; }
        [DataMember] public string strTipoServicio { get; set; }





    }
}
