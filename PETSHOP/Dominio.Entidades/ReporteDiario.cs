using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class ReporteDiario
    {
        [DataMember] public int IdPersonal { get; set; }
        [DataMember] public string Cod_Personal { get; set; }
        [DataMember] public string Persona { get; set; }
        [DataMember] public int IdEmpresa { get; set; }
        [DataMember] public string Cod_Empresa { get; set; }
        [DataMember] public string Dsc_Empresa { get; set; }
        [DataMember] public string Ruc { get; set; }
        [DataMember] public int IdArea { get; set; }
        [DataMember] public string Cod_Area { get; set; }
        [DataMember] public string Dsc_Area { get; set; }
        [DataMember] public int IdGrupo { get; set; }
        [DataMember] public string Cod_Grupo { get; set; }
        [DataMember] public string Dsc_Grupo { get; set; }
        [DataMember] public int IdLocal { get; set; }
        [DataMember] public string Cod_Local { get; set; }
        [DataMember] public string Dsc_Local { get; set; }
        [DataMember] public int IdCategoria { get; set; }
        [DataMember] public string Cod_Categoria { get; set; }
        [DataMember] public string Dsc_Categoria { get; set; }
        [DataMember] public DateTime Fecha { get; set; }
        [DataMember] public int IniRefrigerio { get; set; }
        [DataMember] public int FinRefrigerio { get; set; }
        [DataMember] public int HEntrada { get; set; }
        [DataMember] public int HSalida { get; set; }
        [DataMember] public int HoraEntrada { get; set; }
        [DataMember] public int HoraSalida { get; set; }
        [DataMember] public int HTRAB { get; set; }
        [DataMember] public int HTEFE { get; set; }
        [DataMember] public int HTRABN { get; set; }
        [DataMember] public int HES25 { get; set; }
        [DataMember] public int HES35 { get; set; }
        [DataMember] public int HEN25 { get; set; }
        [DataMember] public int HEN35 { get; set; }
        [DataMember] public int HED25 { get; set; }
        [DataMember] public int HED35 { get; set; }
        [DataMember] public int HEDD { get; set; }
        [DataMember] public int HEDN { get; set; }
        [DataMember] public int HTFEDOM { get; set; }
        [DataMember] public int HE60 { get; set; }
        [DataMember] public int HE100 { get; set; }
        [DataMember] public int HEFD { get; set; }
        [DataMember] public int HEFN { get; set; }
        [DataMember] public int HEDP { get; set; }
        [DataMember] public int NumMarcas { get; set; }
        [DataMember] public int DFalta { get; set; }
        [DataMember] public int DMedico { get; set; }
        [DataMember] public int TIngreso { get; set; }
        [DataMember] public int TRefrigerio { get; set; }
        [DataMember] public int HFerDescanso { get; set; }
        [DataMember] public int DVacaciones { get; set; }
        [DataMember] public int DFeriado { get; set; }
        [DataMember] public int DTrabajado { get; set; }
        [DataMember] public int HJustificado { get; set; }
        [DataMember] public int DJustificado { get; set; }
        [DataMember] public int HAdicional { get; set; }
        [DataMember] public int IdPlanilla { get; set; }
        [DataMember] public int IdCargo { get; set; }
        [DataMember] public int Sueldo { get; set; }
        [DataMember] public int AsignacionFamiliar { get; set; }
        [DataMember] public string NDocumento { get; set; }
        [DataMember] public int Compensado { get; set; }
        [DataMember] public int PermisoNoRecuperado { get; set; }
        [DataMember] public int HFUERA { get; set; }
        [DataMember] public int ETOLS { get; set; }
        [DataMember] public bool Activo { get; set; }
        [DataMember] public int Flg_CargoConfianza { get; set; }
        [DataMember] public string HJustDescrip { get; set; }
        [DataMember] public int HTDIU { get; set; }
        [DataMember] public int HTNOC { get; set; }
        [DataMember] public int HTDOM { get; set; }
        [DataMember] public int TotalHT { get; set; }
        [DataMember] public int HTotales { get; set; }
        [DataMember] public int HExtrasTotales { get; set; }
        [DataMember] public int NSEMANA { get; set; }
        [DataMember] public int NDIA { get; set; }
        [DataMember] public int HFER { get; set; }
        [DataMember] public int BNLC { get; set; }
        [DataMember] public int DCH { get; set; }
        [DataMember] public int DSH { get; set; }
        [DataMember] public int HCH { get; set; }
        [DataMember] public int HSH { get; set; }

    }
}
