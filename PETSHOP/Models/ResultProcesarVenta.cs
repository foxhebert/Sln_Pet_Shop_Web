using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace CBX_Web_PetShopWeb.Models
{
    public class ResultProcesarVenta
    {

        [DataMember] public int intIdProducto   { get; set; }
        [DataMember] public int intRstVendido   { get; set; }
        [DataMember] public int intIdVentaCabe  { get; set; }

    }
}
