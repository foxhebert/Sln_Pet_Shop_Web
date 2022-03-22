using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBX_Web_PetShopWeb.Models
{
    public class CustomResponse
    {
        public string type { get; set; }
        public string message { get; set; }
        public string extramsg { get; set; }
        public object objeto { get; set; }

        public object objetoLista { get; set; }//HG
        public object intIdentifier { get; set; }//HG 17.03.2022
    }
}
