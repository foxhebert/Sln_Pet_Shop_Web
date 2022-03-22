using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
    public class TGTipo
    {

        [DataMember] public int IntIdTipo { get; set; }
        [DataMember] public string strCoTipo { get; set; }
        [DataMember] public string strDeTipo { get; set; }
        [DataMember] public string strAbreviatura { get; set; }
        [DataMember] public string strGrupo { get; set; }
        [DataMember] public string strSubGrupo { get; set; }
        [DataMember] public string DeSubGrupo { get; set; }



    }
}
