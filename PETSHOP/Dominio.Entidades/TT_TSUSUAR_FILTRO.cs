using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TT_TSUSUAR_FILTRO
    {
        [DataMember] public int intIdUsFiltro { get; set; }
        [DataMember] public int intIdUsuar { get; set; }
        [DataMember] public int intIdEmp { get; set; }
        [DataMember] public int intIdLocal { get; set; }
        [DataMember] public int intIdArea { get; set; }
        [DataMember] public bool bitFlActivo { get; set; }
        [DataMember] public bool bitFlEliminado { get; set; }
    }
}
