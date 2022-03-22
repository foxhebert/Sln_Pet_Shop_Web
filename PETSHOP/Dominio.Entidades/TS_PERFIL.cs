using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TS_PERFIL
    {

        [DataMember] public int intIdPerfil { get; set; }

        [DataMember] public string strCoPerfil { get; set; }

        [DataMember] public string strDesPerfil { get; set; }

        [DataMember] public bool bitFlAdmin { get; set; }

        [DataMember] public bool bitTipoPerfil { get; set; }

        [DataMember] public string strTipoPerfil { get; set; }

        [DataMember] public bool bitFlActivo { get; set; }

        [DataMember] public string strFlActivo { get; set; }

        [DataMember] public bool bitFlEliminado { get; set; }

        [DataMember] public int intIdUsuarReg { get; set; }

        [DataMember] public DateTime? dttFeReg { get; set; }

        [DataMember] public int intIdUsuarModif { get; set; }

        [DataMember] public DateTime? dttFeModif { get; set; }

    }
}
