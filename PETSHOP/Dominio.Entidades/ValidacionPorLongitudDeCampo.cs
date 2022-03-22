using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Dominio.Entidades
{
    public class ValidacionPorLongitudDeCampo
    {
        [DataMember] public string NombreColumna { get; set; }

        [DataMember] public int intNumero { get; set; }
    }
}

