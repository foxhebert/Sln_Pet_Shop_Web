//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Dominio.Entidades
//{
//    class IntervaloComedor
//    {
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Dominio.Entidades
{
    public class IntervaloComedor
    {
        [DataMember] public int intIdIntervalo { get; set; }
        [DataMember] public int intIdJornada { get; set; }
        [DataMember] public int intTipoInterval { get; set; }
        [DataMember] public string strCodJornada { get; set; }
        [DataMember] public string strDscJornada { get; set; }
        [DataMember] public int intTipoDia { get; set; }
        [DataMember] public int intHoraIni { get; set; }
        [DataMember] public int intHoraFin { get; set; }
        [DataMember] public string timeHoraIni { get; set; }
        [DataMember] public string timeHoraFin { get; set; }
        [DataMember] public int intTurno { get; set; }
        [DataMember] public int intTolerancia { get; set; }
        [DataMember] public string timeTolerancia { get; set; }
        [DataMember] public int intDuracion { get; set; }
        [DataMember] public int intidTipoServ { get; set; }
        [DataMember] public string timeDuracion { get; set; }
        [DataMember] public int intNuOrden { get; set; }
        [DataMember] public int intTiempoMaximo { get; set; }
        [DataMember] public string timeTiempoMaximo { get; set; }
        [DataMember] public bool bitFlHT { get; set; }
        [DataMember] public bool bitDiaSig { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitPertenecDiaSig { get; set; }
        [DataMember] public string strectra1 { get; set; }
        [DataMember] public string strectra2 { get; set; }
        [DataMember] public string strectra3 { get; set; }
        [DataMember] public string strectra4 { get; set; }
        [DataMember] public string strectra5 { get; set; }
        [DataMember] public string strectra6 { get; set; }
        [DataMember] public string strectra7 { get; set; }
        [DataMember] public string strectra8 { get; set; }
        [DataMember] public string strtipointer { get; set; }


    }
}

