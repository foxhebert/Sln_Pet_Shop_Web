using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BODESOFT.Models
{
    [DataContract]
    public class MD_COMBOS
    {
        [DataMember] public int    intId          { get; set; }
        [DataMember] public string strCodigo      { get; set; }
        [DataMember] public string strDescripcion { get; set; }
        [DataMember] public string strAbreviatura { get; set; }

        //MARCAS
        [DataMember] public int    intIdEntidad   { get; set; }
        [DataMember] public string strDescEntidad { get; set; }

        
    }
}



