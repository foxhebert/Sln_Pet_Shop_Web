using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class ReporteOficial
    {
        [DataMember] public int IdPersonal { get; set; }
        //[DataMember] public string Cod_Personal { get; set; }
        [DataMember] public string Persona { get; set; }
        [DataMember] public string Documento { get; set; }
        //[DataMember] public int IdEmpresa { get; set; }
        [DataMember] public string Dsc_Empresa { get; set; }
        [DataMember] public string Ruc { get; set; }
        [DataMember] public DateTime Fecha { get; set; }
        [DataMember] public int HorarioEntrada { get; set; }
        [DataMember] public int HorarioSalida { get; set; }
        [DataMember] public int HoraEntrada { get; set; }
        [DataMember] public int HoraSalida { get; set; }
        [DataMember] public int HTrabajo { get; set; }
        [DataMember] public int HoraExtra { get; set; }
        [DataMember] public int NumMarcas { get; set; }
        [DataMember] public int DFalta { get; set; }
        [DataMember] public int DFeriado { get; set; }
        //[DataMember] public int DTrabajado { get; set; }
        //[DataMember] public int HEFED { get; set; }
        [DataMember] public int HJustificado { get; set; }
        [DataMember] public int DJustificado { get; set; }
        [DataMember] public string HJustDescrip { get; set; }
        //[DataMember] public int IdArea { get; set; }
        //[DataMember] public int IdGrupo { get; set; }
        //[DataMember] public int IdCategoria { get; set; }
        //[DataMember] public int IdCargo { get; set; }
        //[DataMember] public int IdPlanilla { get; set; }
        [DataMember] public int Compensado { get; set; }
        //[DataMember] public int IdLocal { get; set; }
        //[DataMember] public string Dsc_Local { get; set; }
        //[DataMember] public string Direccion { get; set; }
        //[DataMember] public int TiempoRefrig { get; set; }
        [DataMember] public int Flg_CargoConfianza { get; set; }
        //[DataMember] public string Dsc_Cargo { get; set; }
        //[DataMember] public string Cod_Planilla { get; set; }
        //[DataMember] public DateTime Fec_Ingreso { get; set; }

    }
}