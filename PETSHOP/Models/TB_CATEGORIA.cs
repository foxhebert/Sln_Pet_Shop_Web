using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace CBX_Web_PetShopWeb.Models
{
    public class TB_CATEGORIA
    {

        [DataMember] public int    intIdCategoria      { get; set; }
        [DataMember] public string strCodigoBarraCate  { get; set; }
        [DataMember] public string strCodigoCategoria  { get; set; }
        [DataMember] public string strDescCategoria    { get; set; }
        [DataMember] public string strActivo           { get; set; }

    }
}
