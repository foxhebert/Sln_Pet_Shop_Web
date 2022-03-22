using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class ReportePuntualidad
    {
        [DataMember] public int IdPersonal { get; set; }
        [DataMember] public string Cod_Personal { get; set; }
        [DataMember] public string Persona { get; set; }
        [DataMember] public string Documento { get; set; }
        [DataMember] public int IdEmpresa { get; set; }
        [DataMember] public string Cod_Empresa { get; set; }
        [DataMember] public string Dsc_Empresa { get; set; }
        [DataMember] public string Ruc { get; set; }
        [DataMember] public int IdArea { get; set; }
        [DataMember] public int IdCategoria { get; set; }
        [DataMember] public int IdGrupo { get; set; }
        [DataMember] public int IdLocal { get; set; }
        [DataMember] public int IdPlanilla { get; set; }
        [DataMember] public int IdCargo { get; set; }
        [DataMember] public int IdPeriodo { get; set; }
        [DataMember] public string Dsc_Periodo { get; set; }
        [DataMember] public int Tiempo { get; set; }
        [DataMember] public string Cod_Area { get; set; }
        [DataMember] public string Dsc_Area { get; set; }
        [DataMember] public string VALOR { get; set; }
        [DataMember] public int Total { get; set; }
    }
}
