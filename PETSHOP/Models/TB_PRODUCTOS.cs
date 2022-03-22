using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace BODESOFT.Models
{
    public class TB_PRODUCTOS
    {
        
        [DataMember] public int     intIdProducto          { get; set; }
        [DataMember] public string  strCodigoBarras        { get; set; }
        [DataMember] public string  strCodigoProducto      { get; set; }
        [DataMember] public string  strDescProducto        { get; set; }
        [DataMember] public int     intIdMarcaProducto     { get; set; }
        [DataMember] public string  decPrecioDeVenta       { get; set; }        
        [DataMember] public int     intCantTotalActual     { get; set; }
        [DataMember] public string  decMontoProducto       { get; set; }
        [DataMember] public string  strMarcaProducto       { get; set; }
        [DataMember] public string  strRutaImagenMarca     { get; set; }
        [DataMember] public string  strRutaImagenProducto  { get; set; }
        [DataMember] public string  strDescCategoria       { get; set; }
        [DataMember] public string  strPresentacion        { get; set; }
        [DataMember] public string  strInfoAdicionalProd   { get; set; }

        //PARA EL CONSTRUCTOR Y LA LISTA 
        [DataMember] public int     intCantidadVenta       { get; set; }
        [DataMember] public int     intIdCategoria         { get; set; }
        [DataMember] public string  decPorcentajeDescto    { get; set; }
        [DataMember] public string  decPriceBefore { get; set; }




        //[DataMember] public bool bitFlEliminado { get; set; }
        //[DataMember] public int intIdEntrada { get; set; }
        //[DataMember] public DateTime? dttFeReg { get; set; }
        //[DataMember] public int intIdUsuarModif { get; set; }


    }
}
