using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace BODESOFT.Models
{
    public class TB_TABLAS_INTO_EXCEL
    {
        [DataMember] public string  intIdProducto        { get; set; }
        [DataMember] public string  strCodigoBarras      { get; set; }
        [DataMember] public string  strCodigoProducto    { get; set; }
        [DataMember] public string  strDescProducto      { get; set; }
        [DataMember] public string  strDescCategoria     { get; set; }
        [DataMember] public string  decMontoProductos    { get; set; }
        [DataMember] public string  strMarcaProducto     { get; set; }
        [DataMember] public string  strPresentacion      { get; set; }
        [DataMember] public string  decPrecioDeVenta     { get; set; }
        [DataMember] public string  intCantTotalActual   { get; set; }

    }
}
