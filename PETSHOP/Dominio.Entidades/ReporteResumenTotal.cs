using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class ReporteResumenTotal
    {
        [DataMember] public string Cod_Personal { get; set; }
        [DataMember] public string Persona { get; set; }
        [DataMember] public int IdEmpresa { get; set; }
        [DataMember] public string Cod_Empresa { get; set; }
        [DataMember] public string Dsc_Empresa { get; set; }
        [DataMember] public string Ruc { get; set; }
        [DataMember] public int HTrabajo { get; set; }
        [DataMember] public int HFuera { get; set; }
        [DataMember] public int HTardanza { get; set; }
        [DataMember] public int HAdicionales { get; set; }
        [DataMember] public int HTardanzaRefrig { get; set; }
        [DataMember] public int DFalta { get; set; }
        [DataMember] public int DAsistencia { get; set; }
        [DataMember] public int ETOLS { get; set; }
        [DataMember] public int PNR { get; set; }
        [DataMember] public int IdPlanilla { get; set; }
        [DataMember] public string Cod_Planilla { get; set; }
        [DataMember] public string Dsc_Planilla { get; set; }
        [DataMember] public int IdPeriodo { get; set; }
        [DataMember] public string Dsc_Periodo { get; set; }
        [DataMember] public int idPersonal { get; set; }
        [DataMember] public int IdArea { get; set; }
        [DataMember] public int IdLocal { get; set; }
        [DataMember] public int IdGrupo { get; set; }
        [DataMember] public int IdCategoria { get; set; }
        [DataMember] public int IdCargo { get; set; }
        [DataMember] public int Sueldo { get; set; }
        [DataMember] public int AsignacionFamiliar { get; set; }
        [DataMember] public string Cod_Area { get; set; }
        [DataMember] public string Dsc_Area { get; set; }
        [DataMember] public string Cod_Categoria { get; set; }
        [DataMember] public string Dsc_Categoria { get; set; }
        [DataMember] public int NTardanza { get; set; }
        [DataMember] public int DTEfectivo { get; set; }
        [DataMember] public int HE25 { get; set; }
        [DataMember] public int HE35 { get; set; }
        [DataMember] public int HEDOB { get; set; }
        [DataMember] public int HEN25 { get; set; }
        [DataMember] public int HEN35 { get; set; }
        [DataMember] public int HENDOB { get; set; }
        [DataMember] public int DVacaciones { get; set; }
        [DataMember] public int DPermiso { get; set; }
        [DataMember] public int DLicencia { get; set; }
        [DataMember] public int DDesMedico { get; set; }
        [DataMember] public int DSubsidio { get; set; }
        [DataMember] public int DSuspension { get; set; }
        [DataMember] public int Permiso { get; set; }

    }
}
