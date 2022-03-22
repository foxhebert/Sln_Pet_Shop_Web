using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Periodo
    {

        [DataMember] public int intIdPeriodo { get; set; }
        [DataMember] public int intIdDependencia { get; set; }
        [DataMember] public int intIdUnidadOrg { get; set; }
        [DataMember] public int intIdPlani { get; set; }
        [DataMember] public string strDesPlani { get; set; }
        [DataMember] public string strCoPeriodo { get; set; }
        [DataMember] public string strDesPeriodo { get; set; }
        [DataMember] public string dttFeIniPerio { get; set; }
        [DataMember] public string dttFeFinPerio { get; set; }
        [DataMember] public string dttFeCiePerio { get; set; }
        [DataMember] public int intAnioFiscal { get; set; }
        [DataMember] public int intMes { get; set; }
        [DataMember] public string strMesAnio { get; set; }
        [DataMember] public bool bitFlProyectado { get; set; }
        [DataMember] public bool bitCerrado { get; set; }
        [DataMember] public string strPeriodoCampo1 { get; set; }
        [DataMember] public string strPeriodoCampo2 { get; set; }
        [DataMember] public string strPeriodoCampo3 { get; set; }
        [DataMember] public string strPeriodoCampo4 { get; set; }
        [DataMember] public string strPeriodoCampo5 { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public DateTime? dttFeRegistro { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }
        [DataMember] public string strDependencia { get; set; }
        [DataMember] public string strEstadoCerrado { get; set; }
        [DataMember] public string strEstadoActivo { get; set; }
        [DataMember] public int intCalculado { get; set; }//añadido 25.02.2021

    }
}
