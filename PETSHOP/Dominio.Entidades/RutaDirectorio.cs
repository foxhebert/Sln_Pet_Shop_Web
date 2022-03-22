using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
    public class RutaDirectorio
    {
        [DataMember] public string strDesRuta { get; set; }
        [DataMember] public String strIpSession { get; set; }

    }
}
