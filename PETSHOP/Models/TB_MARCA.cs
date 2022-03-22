using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace CBX_Web_PetShopWeb.Models
{
    public class TB_MARCA
    {

        [DataMember] public int    intIdMarca         { get; set; }
        [DataMember] public string strCodigoMarca     { get; set; }
        [DataMember] public string strDescMarca       { get; set; }
        [DataMember] public string strRutaImgMarca    { get; set; }
        [DataMember] public int    bitFlEliminado     { get; set; }

        //[DataMember] public string strRutaMarca     { get; set; }
        //intIdMarca
        //strCodigoMarca
        //    strMarcaProducto
        //    strRutaImagenMarca
        //    bitFlEliminado

    }
}
