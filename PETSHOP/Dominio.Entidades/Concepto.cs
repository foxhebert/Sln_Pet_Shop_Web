using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Concepto
    {

        [DataMember] public int intIdConcepto { get; set; }
        [DataMember] int intIdSoft { get; set; }
        [DataMember] public int intTipoConcepto { get; set; }
        [DataMember] public bool bitInternoSis { get; set; }
        [DataMember] public string strCoConcepto { get; set; }
        [DataMember] public string strDesConcepto { get; set; }
        [DataMember] public int bitReqMarca { get; set; }
        [DataMember] public string strCoPlaniExp { get; set; }
        [DataMember] public string strCoPDT { get; set; }
        [DataMember] public int intTipoUM { get; set; }
        [DataMember] public bool bitAplTodosDias { get; set; }
        [DataMember] public bool bitAplDiaLabor { get; set; }
        [DataMember] public bool bitAplDiaDescanso { get; set; }
        [DataMember] public bool bitAplDiaFeriado { get; set; }
        [DataMember] public bool bitAplDiaSabado { get; set; }
        [DataMember] public bool bitAplDiaDomingo { get; set; }
        [DataMember] public int intIdTipRegimen { get; set; }
        [DataMember] public bool bitClasifica { get; set; }
        [DataMember] public int smlTipoRedondeo { get; set; }
        [DataMember] public int smlAplicaRedond { get; set; }
        [DataMember] public int intTiempoRedond { get; set; }
        [DataMember] public int smlFormaRedond { get; set; }
        [DataMember] public bool bitFlHT { get; set; }
        [DataMember] public bool bitFlDT { get; set; }
        [DataMember] public bool bitFlHTE { get; set; }
        [DataMember] public bool bitFlGenerarHA { get; set; }
        [DataMember] public bool bitFlUtilidades { get; set; }
        [DataMember] public bool bitFlCTS { get; set; }
        [DataMember] public bool bitExportPlani { get; set; }
        [DataMember] public bool bitFlSubsidio { get; set; }
        [DataMember] public bool bitFlDiaNoLabNiSub { get; set; }
        [DataMember] public int intTiempoRTardanza { get; set; }
        [DataMember] public int tinFlCompensacion { get; set; }
        [DataMember] public int tinPrioridadHE { get; set; }
        [DataMember] public int intIdTipBoni { get; set; }
        [DataMember] public int intHoraIni { get; set; }
        [DataMember] public int intHoraFin { get; set; }
        [DataMember] public int intTolerancia { get; set; }
        [DataMember] public int intTiempoMin { get; set; }
        [DataMember] public bool bitSustentacion { get; set; }
        [DataMember] public int intUsoMaximo { get; set; }
        [DataMember] public string strConceptoCampo1 { get; set; }
        [DataMember] public string strConceptoCampo2 { get; set; }
        [DataMember] public string strConceptoCampo3 { get; set; }
        [DataMember] public string strConceptoCampo4 { get; set; }
        [DataMember] public string strConceptoCampo5 { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public bool bitFlGrati { get; set; }
        [DataMember] public bool bitFlDescontable { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public DateTime? dttFeRegistro { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }

        [DataMember] public string strActivo { get; set; }
        [DataMember] public string strDeTipotipo { get; set; }

        [DataMember] public string strDeTipoum { get; set; }

        [DataMember] public string strDeTipoReg { get; set; }

        [DataMember] public string strDeTipoBoni { get; set; }

        [DataMember] public string timeHoraIni { get; set; }

        [DataMember] public string timeHoraFin { get; set; }

        [DataMember] public string timeTolerancia { get; set; }

        [DataMember] public string timeTiempoMin { get; set; }
        [DataMember] public bool bitJornadaEspecif { get; set; }

        [DataMember] public bool bitHoraIni { get; set; }
        [DataMember] public bool bitHoraFin { get; set; }
    }
}