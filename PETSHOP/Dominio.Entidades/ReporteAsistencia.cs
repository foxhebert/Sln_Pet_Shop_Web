using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class ReporteAsistencia
    {
        [DataMember] public string Dsc_Empresa { get; set; }
        [DataMember] public string Ruc { get; set; }
        [DataMember] public string Cod_Personal { get; set; }
        [DataMember] public string Persona { get; set; }
        [DataMember] public string Dsc_Local { get; set; }
        [DataMember] public string Direccion { get; set; }
        [DataMember] public string Documento { get; set; }
        [DataMember] public DateTime fecha { get; set; }
        [DataMember] public string Cod_Area { get; set; }
        [DataMember] public string Dsc_Area { get; set; }
        [DataMember] public string Dia { get; set; }
        [DataMember] public string Marca1 { get; set; }
        [DataMember] public string Marca2 { get; set; }
        [DataMember] public string Marca3 { get; set; }
        [DataMember] public string Marca4 { get; set; }
        [DataMember] public string Marca5 { get; set; }
        [DataMember] public string Marca6 { get; set; }
        [DataMember] public string Marca7 { get; set; }
        [DataMember] public string Marca8 { get; set; }
        [DataMember] public string Horario { get; set; }
        [DataMember] public string no_fiscalizado { get; set; }
        [DataMember] public string Dsc_Marcador { get; set; }
        
    }
}
