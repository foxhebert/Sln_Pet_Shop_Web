using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TS_MENU
    {

        [DataMember] public int intIdMenu { get; set; }

        [DataMember] public int intIdSoft { get; set; }

        [DataMember] public string strCoMenu { get; set; }

        [DataMember] public string strNomMenu { get; set; }

        [DataMember] public string strDesMenu { get; set; }

        [DataMember] public string strNomFormu { get; set; }

        [DataMember] public string strDesFormu { get; set; }

        [DataMember] public string strCoMenuRela { get; set; }

        [DataMember] public int intDeModos { get; set; }

        [DataMember] public int intNuOrden { get; set; }

        [DataMember] public int intIdMosai { get; set; }

        [DataMember] public int intNuIndexLista { get; set; }

        [DataMember] public bool bitFlActivo { get; set; }


        // extras strSubMenu
        [DataMember] public string strSubMenu { get; set; }
        [DataMember] public int intIsSelecc { get; set; }

        [DataMember] public int contador { get; set; }
        
    }
}
