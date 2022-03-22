using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class DashboardTortas
    {
        [DataMember] public int intValorUno { get; set; }
        [DataMember] public int intValorDos { get; set; }

    }
}
