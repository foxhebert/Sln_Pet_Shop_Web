using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
    public class ReporteTotalComedor
    {

        [DataMember] public int IdPersonal { get; set; }
        [DataMember] public string Cod_Personal { get; set; }
        [DataMember] public string Persona { get; set; }
        [DataMember] public string Fotochek { get; set; }
        [DataMember] public string Dsc_Empresa { get; set; }
        [DataMember] public string Ruc { get; set; }
        [DataMember] public DateTime? rHora { get; set; }
        [DataMember] public string sDesServicio { get; set; }
        [DataMember] public int NumConsumos { get; set; }
        [DataMember] public decimal dcCosto { get; set; }
        [DataMember] public string Moneda { get; set; }
        [DataMember] public decimal PrecioUnitario { get; set; }
        [DataMember] public decimal dcSubsidiado { get; set; } //11.03.2021








    }
}
