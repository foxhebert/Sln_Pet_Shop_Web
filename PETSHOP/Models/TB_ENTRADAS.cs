using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Text;

namespace BODESOFT.Models
{
    public class TB_ENTRADAS
    {
        
        [DataMember] public int       intIdEntrada  { get; set; }
        [DataMember] public string    strCodigo     { get; set; }
        [DataMember] public string    strProducto   { get; set; }
        [DataMember] public string    strMarca      { get; set; }
        [DataMember] public decimal   decPrecUnit   { get; set; }
        [DataMember] public decimal   decPrecVenta  { get; set; }
        [DataMember] public int       intCantidad   { get; set; }
        [DataMember] public decimal   decPrecCosto  { get; set; }
        [DataMember] public decimal   decMonto      { get; set; }
        [DataMember] public DateTime  dttFechIngre  { get; set; }
        [DataMember] public string    strProveedor  { get; set; }
        [DataMember] public string    strAnotacion  { get; set; }


        
        [DataMember] public string    strCodigoBarras     { get; set; }
        [DataMember] public string    strCodProducto   { get; set; }
        [DataMember] public string    strDesProducto   { get; set; }
        [DataMember] public string    strMarcaProd     { get; set; }
        [DataMember] public decimal   decPrecioDeVenta { get; set; }
        //intIdEntrada
        //strCodProducto
        //strDesProducto
        //strMarcaProd

        //////////intIdEntrada
        //////////strCodigo
        //////////strProducto
        //////////strMarca
        //////////decPrecUnit

        //////////decPrecVenta
        //////////intCantidad
        //////////decPrecCosto
        //////////decMonto
        //////////dttFechIngre

        //////////strProveedor
        //////////strAnotacion
        //            [DataMember] public string strDesEstado { get; set; }
        //[DataMember] public bool bitFlEliminado { get; set; }
        //[DataMember] public int intIdEntrada { get; set; }
        //[DataMember] public DateTime? dttFeReg { get; set; }
        //[DataMember] public int intIdUsuarModif { get; set; }
        //[DataMember] public DateTime? dttFeModif { get; set; }


    }
}