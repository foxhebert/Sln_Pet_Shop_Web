using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Dominio.Entidades
{
    public class ValidacionesxLongitud
    {
        [DataMember] public string NombreColum { get; set; }

        [DataMember] public int intNumero { get; set; }
    }
}

