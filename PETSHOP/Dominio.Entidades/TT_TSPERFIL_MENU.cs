using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TT_TSPERFIL_MENU
    {

        [DataMember] public int intIdPerfM { get; set; }

        [DataMember] public int intIdPerfil { get; set; }

        [DataMember] public int intIdSoft { get; set; }

        [DataMember] public int intIdMenu { get; set; }

        [DataMember] public bool bitFlEliminado { get; set; }




    }
}
