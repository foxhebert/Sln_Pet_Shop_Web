using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace CBX_Web_PetShopWeb.Models
{
    public class TB_VENTA_CABE
    {

        [DataMember] public int      intIdVentaCabe       { get; set; }
        [DataMember] public string   strCodVenta          { get; set; }
        [DataMember] public string   strRucCliente        { get; set; }
        [DataMember] public string   strNomCliente        { get; set; }       
        [DataMember] public string   strApeCliente        { get; set; }
        [DataMember] public string   strMoneda            { get; set; }
        [DataMember] public string   strDirCliente        { get; set; }      
        [DataMember] public string   strTelCliente        { get; set; }
        [DataMember] public string   decMontoTotDeVenta   { get; set; }
        [DataMember] public string   dttDateTimeVenta     { get; set; }
        [DataMember] public string   strMedioDePago       { get; set; }      
        [DataMember] public string   decPagoConIzipay     { get; set; }

    }
}
