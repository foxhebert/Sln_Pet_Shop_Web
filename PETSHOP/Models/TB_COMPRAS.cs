using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Text;

namespace BODESOFT.Models
{
    public class TB_COMPRAS
    {

        //AÑADIDO PARA TRABAJAR SOLO PARA EL MANTENIMIENTOS COMPRAS
        [DataMember] public int       intIdCompra        { get; set; }
        [DataMember] public string    strCodigoCompra    { get; set; }
        [DataMember] public int       intIdProducto      { get; set; }        
        [DataMember] public string    strCodigoProducto  { get; set; }
        [DataMember] public int       intCantIngresada   { get; set; }
        [DataMember] public string    decCostoUnitCompra { get; set; }
        [DataMember] public string    decMontoTotCompra  { get; set; }
        [DataMember] public String    dttFechaIngreso    { get; set; }
        [DataMember] public String    strDescMarcaProd   { get; set; }
        [DataMember] public String    strCodigoBarras    { get; set; }
        [DataMember] public string    dttFechaVencimiento{ get; set; }
        [DataMember] public string    strNumDocCompra    { get; set; }
        [DataMember] public string    strDesProveedor    { get; set; }
        [DataMember] public int       intStockPrevio     { get; set; }


        //AL EDITAR COMPRA
        [DataMember] public string  strDescProducto        { get; set; }
        [DataMember] public string  decPrecioDeVenta       { get; set; }        
        [DataMember] public int     intCantTotalActual     { get; set; }
        [DataMember] public string  decMontoProducto       { get; set; }
        [DataMember] public string  strRutaImagenProducto  { get; set; }



        //[DataMember] public decimal   decPrecioUnitCosto { get; set; }
        //[DataMember] public DateTime  dttFechIngre  { get; set; }
        //[DataMember] public string    strAnotacion  { get; set; }
        //[DataMember] public bool bitFlEliminado { get; set; }
        //[DataMember] public int intIdEntrada { get; set; }
        //[DataMember] public DateTime? dttFeReg { get; set; }



    }
}
