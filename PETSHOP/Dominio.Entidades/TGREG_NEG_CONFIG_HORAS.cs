using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TGREG_NEG_CONFIG_HORAS
    {
        [DataMember] public int intIdRegNegHE { get; set; }
        [DataMember] public int intIdReglaNeg { get; set; }
        [DataMember] public int intIdConceptoDiurno { get; set; }
        [DataMember] public int intIdConceptoNocturno { get; set; }
        [DataMember] public int intTiempo { get; set; }
        [DataMember] public string timeTiempo { get; set; }
        [DataMember] public int intSecuencia { get; set; }
        [DataMember] public int intTipoDia { get; set; }
        [DataMember] public int intTipoHorario { get; set; }
        [DataMember] public int bitFlEliminado { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }

        [DataMember] public string strTipoDia { get; set; }
        [DataMember] public string strDesConcepto1 { get; set; }
        [DataMember] public string strDesConcepto2 { get; set; }




    }
}
