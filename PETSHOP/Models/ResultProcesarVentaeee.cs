using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Collections;

namespace Dominio.Entidades
{
    public class ResultProcesarVenta
    {

        //[DataMember] public int intInsertado { get; set; } 
        //[DataMember] public int intActualizado { get; set; }
        //[DataMember] public int intInconsistente { get; set; }
        //[DataMember] public String strInconsistente { get; set; }
        //[DataMember] public String strNombreTabla { get; set; }
        //[DataMember] public List<string> arrListInconsistentes;

        [DataMember] public int intIdProducto { get; set; }
        [DataMember] public int intRstVendido { get; set; }

        //[DataMember] public List<string> arrListResultVenta;

    }
}
