using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class ReporteAusencia
    {
        [DataMember] public string Cod_Personal { get; set; }
        [DataMember] public string Persona { get; set; }
        [DataMember] public string Documento { get; set; }
        [DataMember] public int IdEmpresa { get; set; }
        [DataMember] public string Cod_Empresa { get; set; }
        [DataMember] public string Dsc_Empresa { get; set; }
        [DataMember] public string Ruc { get; set; }
        [DataMember] public string Cod_Concepto { get; set; }
        [DataMember] public string Concepto { get; set; }
        [DataMember] public string Unidad_Tiempo { get; set; }
        [DataMember] public DateTime? Fecha { get; set; }
        [DataMember] public int Tiempo { get; set; }
        [DataMember] public string HTiempo { get; set; }
        [DataMember] public int IdPersonal { get; set; }
        [DataMember] public int IdCategoria { get; set; }
        [DataMember] public int IdArea { get; set; }
        [DataMember] public int IdLocal { get; set; }
        [DataMember] public int IdGrupo { get; set; }
        [DataMember] public int IdPlanilla { get; set; }
        [DataMember] public int IdCargo { get; set; }
        [DataMember] public string Observacion { get; set; }
        [DataMember] public string Cod_Area { get; set; }
        [DataMember] public string Dsc_Area { get; set; }
        [DataMember] public string Dsc_Categoria { get; set; }
        [DataMember] public string NDocumento { get; set; }
        [DataMember] public string Cod_Cargo { get; set; }
        [DataMember] public string Dsc_Cargo { get; set; }
        [DataMember] public string Cod_Grupo { get; set; }
        [DataMember] public string Dsc_Grupo { get; set; }
        [DataMember] public bool ACTIVO { get; set; }
        [DataMember] public int IDCONCEPTO { get; set; }
        [DataMember] public int MINUTOS { get; set; }
        [DataMember] public string Horario { get; set; }
        [DataMember] public int TiempoMaximo { get; set; }
        [DataMember] public string TipoConcepto { get; set; }
    }
}
