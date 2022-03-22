using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace CBX_Web_PetShopWeb.Models
{
    public class TB_VENTA_DETA
    {

        [DataMember] public int      intIdVenta           { get; set; }
        [DataMember] public int      intIdVentaCabe       { get; set; }
        [DataMember] public int      intIdProducto        { get; set; }
        [DataMember] public string   decPrecUnitDeVenta   { get; set; }       
        [DataMember] public int      intCantidadDeVenta   { get; set; }
        [DataMember] public string   decMontoTotDeVenta   { get; set; }
        [DataMember] public string   decCostoUnitCompra   { get; set; }      
        [DataMember] public string   decMontoGanancia     { get; set; }
        [DataMember] public string   dttDateTimeInserted  { get; set; }
        [DataMember] public string   dttDateTimeUpdated   { get; set; }
        [DataMember] public string   bitFlDeleted         { get; set; }
        
        [DataMember] public string   strCodigoProducto    { get; set; }      
        [DataMember] public string   strCodVenta          { get; set; }      


    }
}
